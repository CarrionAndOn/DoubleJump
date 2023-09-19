using BoneLib;

namespace DoubleJump
{
    public class DoubleJump
    {
        public void Enable()
        {
            Player.remapRig.doubleJump = true;
        }
        public void Disable()
        {
            Player.remapRig.doubleJump = false;
        }

        public void AutoEnable()
        {
            if (Main.Enabled)
            {
                Player.remapRig.doubleJump = true;
            }
        }
    }
}