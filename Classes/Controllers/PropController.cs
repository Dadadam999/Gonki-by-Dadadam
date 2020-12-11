namespace Gonki_by_Dadadam
{
    public class PropController
    {
        public PropBoost PropBoostPlayer { get; set; }
        public PropBoost PropBoostEnemy { get; set; }
        public PropStopTrack PropStopPlayer { get; set; }
        public PropStopTrack PropStopEnemy { get; set; }

        public PropController(PlayerController playerController, EnemyController enemyController)
        {
            PropBoostPlayer = new PropBoost(playerController)
            { Name = "PropBoostPlayer" };

            PropBoostEnemy = new PropBoost(enemyController)
            { Name = "PropBoostEnemy" };

            PropStopPlayer = new PropStopTrack(playerController);
            PropStopEnemy = new PropStopTrack(enemyController);
        }

        public void Update(float widthScreen)
        {
            PropBoostPlayer.Current_Position();
            PropBoostEnemy.Current_Position();

            PropStopPlayer.Remove(widthScreen);
            PropStopEnemy.Remove(widthScreen);

            PropStopPlayer.Update(PropStopPlayer.Controller.Car.CurrentSpeed * -1);
            PropStopEnemy.Update(PropStopPlayer.Controller.Car.CurrentSpeed * -1);
        }
    }
}