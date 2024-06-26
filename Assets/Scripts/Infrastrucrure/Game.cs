using VContainer.Unity;

namespace Screpts.Infrastructure
{
    public class Game : IStartable
    {
        public GameStateMachine StateMachine;

        public Game(GameBootstrapper gameBootstrapper)
        {
            StateMachine = new GameStateMachine(new SceneLoader(gameBootstrapper));
        }

        public void Start()
        {
            StateMachine.Enter<BootstrapState>();
        }
    }
}