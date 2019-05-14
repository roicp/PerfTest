namespace PerftTest.MiddlewarePipeline
{
    public interface IHandler<in T> where T : Command
    {
        void Handle(T command);
    }
}
