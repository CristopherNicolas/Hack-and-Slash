using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
     class QuickTimeEvens : MonoBehaviour
    {
        [SerializeField] public GameObject QTEPrefab;
        public IEnumerator StartQuickTimeEvent(Enemy enemy , Predicate<bool> p)
        {
             var obj =   Instantiate(QTEPrefab, new Vector3
                (enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z),
                Quaternion.identity);

            yield return new WaitForSeconds(5);
            Destroy(obj);
            
        }
    }
}
