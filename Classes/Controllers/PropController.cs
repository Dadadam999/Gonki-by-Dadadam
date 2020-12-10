using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            {
                Name = "PropBoostPlayer"
            };
            
            PropBoostEnemy = new PropBoost(enemyController)
            {
                Name = "PropBoostEnemy"
            };

            PropStopPlayer = new PropStopTrack(playerController);
            PropStopEnemy = new PropStopTrack(enemyController);
        }

        public void update(float WidthScreen) 
        {
            PropBoostPlayer.current_position();
            PropBoostEnemy.current_position();

            PropStopPlayer.remove(WidthScreen);
            PropStopEnemy.remove(WidthScreen);

            PropStopPlayer.update(PropStopPlayer.Controller.Car.Current_Speed * -1);
            PropStopEnemy.update(PropStopPlayer.Controller.Car.Current_Speed * -1);
        }
    }
}