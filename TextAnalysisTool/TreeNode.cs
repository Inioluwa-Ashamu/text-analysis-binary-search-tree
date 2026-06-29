public class TreeNode
{
    public WordInfo Data { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(WordInfo data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}
