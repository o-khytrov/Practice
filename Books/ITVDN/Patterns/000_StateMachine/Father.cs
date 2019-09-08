namespace _000_StateMachine
{
    class Father
    {
        internal State State { get; set; }
        public Father() { State = new NeutralState(); }
        public void FindOut(Mark mark)
        {
            State.HandleMark(this, mark);
        }
    }
}
