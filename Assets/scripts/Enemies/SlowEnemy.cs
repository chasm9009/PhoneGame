public class SlowEnemy : BaseEnemy
{
    public override void UpdateGravityScale()
    {
        gravityScale = 0.5f;
    }
}