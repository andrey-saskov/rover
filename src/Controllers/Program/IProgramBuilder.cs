namespace Rover.Controllers.Program
{
    public interface IProgramBuilder
    {
        IProgram BuildProgram(string programText);
    }
}