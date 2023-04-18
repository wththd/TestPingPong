using PingPongGame.Scripts.Infrastructure.UIElements;

namespace PingPongGame.Scripts.Infrastructure.Factories
{
    public interface IUIFactory
    {
        MainMenu CreateMainMenuUI();
        CustomizeBallScreen CreateCustomizeBallScreen();
        GameModeScreen CreateGameModeScreen();
        GameCountdownScreen CreateGameCountdownScreen();
        GamePauseScreen CreateGamePauseScreen();
        GamePlayingScreen CreateGamePlayingScreen();
        GameEndScreen CreateGameEndScreen();
    }
}