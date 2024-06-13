using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ParabolicTrjectroy : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int resloution = 30;
    public float timeStep = 0.1f;

    public Transform IaunchPoint;
    public float myRoataion;
    public float IaunchPower;
    public float IaunchAngle;
    public float IaunchDirection;
    public float gravity = -9.8f;
    public GameObject projectillePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderTrajectory();

        if(Input.GetKeyDown(KeyCode.Space))

        {
            LaunProjectile(projectillePrefabs);
        }
    }

    void RenderTrajectory()
    {
        lineRenderer.positionCount = resloution; //
        Vector3[] points = new Vector3[resloution];

        for(int i =0; i< resloution; i++)
        {
            float t = i * timeStep;
            points[i] = CalcualatePositionAtTime(t);
        }
        lineRenderer.SetPositions(points);
    }

    Vector3 CalcualatePositionAtTime(float time)
    {
        float IaunAngleRad = Mathf.Deg2Rad * IaunchAngle;
        float IaunchDiretionRad = Mathf.Deg2Rad * IaunchDirection;

        //시간 t에서의 x,y,z 좌표 계산
        float x = IaunchPower * time * Mathf.Cos(IaunAngleRad) * Mathf.Cos(IaunchDiretionRad);
        float z= IaunchPower * time * Mathf.Cos(IaunAngleRad) * Mathf.Sin(IaunchDiretionRad);
        float y = IaunchPower * time * Mathf.Cos(IaunAngleRad) + 0.5f * gravity * time * time;

        //발사 위치를 기준으로 계산된 위치 반환
        return IaunchPoint.position + new Vector3(x, y, z);
    }

    //물체를 발사하는 함수
    public void LaunProjectile(GameObject _object)
    {
        GameObject temp = Instantiate(_object);
        temp.transform.position = IaunchPoint.position;
        temp.transform.rotation = IaunchPoint.rotation;


        Rigidbody rd = temp.GetComponent<Rigidbody>();
        if(rd == null)
        {
            rd = temp.AddComponent<Rigidbody>();
        }

        if (rd != null)
        {
            rd.isKinematic = false;

            float IaunAngleRad = Mathf.Deg2Rad * IaunchAngle;
            float IaunchDiretionRad = Mathf.Deg2Rad * IaunchDirection;

            float initaVelocityX = IaunchPower * Mathf.Cos(IaunAngleRad) * Mathf.Cos(IaunchDiretionRad);
            float initaVelocityY = IaunchPower * Mathf.Cos(IaunAngleRad) * Mathf.Sin(IaunchDiretionRad);
            float initaVelocityZ = IaunchPower * Mathf.Sin(IaunAngleRad);

            Vector3 initiaiVelocit = new Vector3(initaVelocityX, initaVelocityY, initaVelocityZ);

            rd.velocity = initiaiVelocit;
        }
    }
}
