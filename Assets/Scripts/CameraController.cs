using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController: MonoBehaviour
    {
        /*
 camera effects:
damping
shake
zoom in
zoom out
coliciones
cambio de angulo
cambiar target
tiempo por duracion

contador de golpes
quick time events
cinematicas
*/
        public CinemachineVirtualCamera virtualCamera;
        Cinemachine3rdPersonFollow rig;
        public Transform playerTarget;
        public static CameraController instance;
        private void Awake()
        {
            instance = this;
            rig = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

        }
        private void Update()
        {
            //pruebas -> borrar despues 
            if (Input.GetMouseButtonDown(0))
            {
                // CameraShake(1,.5f,90,1f);
                StartCameraAngle(3,1);
            }
        }
        public async void CameraShake(float duration,float strenght,int vibrato,float randomless)
        {
           await playerTarget.DOShakePosition(duration, strenght, vibrato, randomless).AsyncWaitForCompletion();
            
        }
        public void CameraDamping(float newDamping)
        {
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = newDamping; 
        }

        public void StartCameraZoomIn(float _newFov) => StartCoroutine(CameraZoomIn(_newFov));
        IEnumerator CameraZoomIn(float newFOV)
        {
            for (float i =  virtualCamera.m_Lens.FieldOfView; i <  newFOV; i+=.1f)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                virtualCamera.m_Lens.FieldOfView = i;
            }

        }
        public void StartCameraZoomOut(float _newFov) => StartCoroutine(CameraZoomOut(_newFov));
        IEnumerator CameraZoomOut(float newFOV)
        {
            for (float i = virtualCamera.m_Lens.FieldOfView; i > newFOV; i -= .1f)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                virtualCamera.m_Lens.FieldOfView = i;
            }

        }
     
        public void StartCameraAngle(float _angle,float _time) => StartCoroutine(CameraAngle(_angle,_time));
        IEnumerator CameraAngle(float angle, float time)
        {
            if( angle > rig.ShoulderOffset.y)
            {
                for (float i = rig.ShoulderOffset.y; i < angle; i+= Time.deltaTime)
                {
                    rig.ShoulderOffset.y = i;
                     yield return new WaitForSeconds(Time.deltaTime);
                }

            }
            else
            {
                for (float i = rig.ShoulderOffset.y; i > angle; i -= Time.deltaTime)
                {
                    rig.ShoulderOffset.y = i;
                    yield return new WaitForSeconds(Time.deltaTime);
                }
            }

            yield break;
        }
        public void CameraTarget(Transform target)
        {
            virtualCamera.LookAt = target;
        }
        public void ChangeFollowTarget(Transform t) => virtualCamera.Follow = t;
        public void CameraTime(float _scale, float _time) => StartCoroutine(ChangeCameraTime(_scale,_time));
        public IEnumerator ChangeCameraTime(float scale,float time)
        {
            var startScale = Time.time;
            Time.timeScale = scale;
            yield return new WaitForSeconds(time);
            Time.timeScale = startScale;
        }
    }
}