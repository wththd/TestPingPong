namespace PingPongGame.Scripts.Infrastructure.StateMachine
{
    public abstract class State<TStateIntent> : StateWithoutIntent
    {
        protected TStateIntent Intent;
        
        public void SetIntent(TStateIntent intent)
        {
            Intent = intent;
        }
    }
}