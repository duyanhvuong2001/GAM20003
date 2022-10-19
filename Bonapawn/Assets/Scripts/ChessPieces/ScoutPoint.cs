using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;
namespace Assets.Scripts.ChessPieces
{
    public class ScoutPoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Entered");
            if(collision.tag == "enemy")
            {
                collision.SendMessage("SwapScoutPoint");
            }
        }
    }
}
