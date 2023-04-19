Shader "Custom/BallShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _ContactColor ("Contact Color", Color) = (1,1,1,1)
        _ContactPoint("ContactPoint", Vector) = (-10,-10,10)
        _Contact("Contacted time", Float) = 0
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Distance ("Distance", Float) = 0.8
        _AnimTime ("AnimTime", Float) = 1
    }
    SubShader
    {
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
        
        struct Input
        {
            float distFromHitPoint;
        };

        half _Glossiness;
        half _Metallic;
        float3 _ContactPoint;
        fixed4 _Color;
        fixed4 _ContactColor;
        float _Contact;
        float _Distance;
        float _AnimTime;

        struct appdata
        {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
        };

        void vert(inout appdata v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            o.distFromHitPoint = _Contact != 0 ? distance(_ContactPoint, v.vertex.xyz) : _Distance + 1;
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float blend = IN.distFromHitPoint < _Distance ? lerp(1, 0, IN.distFromHitPoint / _Distance) : 0;
            blend *= lerp(1, 0, saturate((_Time.y - _Contact) / _AnimTime));
            o.Albedo = IN.distFromHitPoint < _Distance ? lerp (_Color, _ContactColor, blend) : _Color.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
