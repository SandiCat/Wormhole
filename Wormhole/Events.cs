namespace Wormhole
{
    public static class Events
    {
        public static event NoArgsDelegate Update;
        public static event NoArgsDelegate UpdateEnded;
        public static event NoArgsDelegate Draw;
        public delegate void NoArgsDelegate();

        public static void RiseUpdate()
        {
            if (Update != null) Update();
        }
        public static void RiseUpdateEnded()
        {
            if (UpdateEnded != null) UpdateEnded();
        }
        public static void RiseDraw()
        {
            if (Draw != null) Draw();
        }
    }
}