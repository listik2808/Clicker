namespace Screpts.Infrastructure
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}