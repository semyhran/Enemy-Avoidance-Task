namespace Project.Enemies
{
    public class MineFlow : Enemy
    {
        protected override void GroundCollision()
        {
            _rigidbody.isKinematic = true;
        }
    }
}

