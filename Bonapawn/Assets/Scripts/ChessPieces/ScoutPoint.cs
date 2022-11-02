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
            if (collision.gameObject.tag == "enemy")
            {
                collision.gameObject.SendMessage("SwapScoutPoint");
            }
        }
    }
}
