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
        }

        public void update() 
        {
            PropBoostPlayer.current_position();
            PropBoostEnemy.current_position();
        }
    }
}