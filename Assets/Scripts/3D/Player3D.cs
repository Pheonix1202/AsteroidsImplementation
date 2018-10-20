using Asteroids;

public class Player3D : Player2D, IPlayer
{
    public override void OnLaserChargeCountChanged(object sender, LaserEventArgs e)
    {
        print(string.Format("{0} charges available", e.Charges));
    }
}
