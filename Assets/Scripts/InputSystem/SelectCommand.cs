public class SelectCommand : ICommand
{
    public void execute(BlockBehaviour blockBehaviour)
    {
        IBlock block = blockBehaviour.block.iBlock;
        block.explode(blockBehaviour);
    }
}