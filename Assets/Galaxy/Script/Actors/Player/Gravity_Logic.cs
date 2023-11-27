//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Gravity_Logic : MonoBehaviour
//{
//    ReverseMesh reverseMesh;

//    //Player��Transform
//    private Transform myTransform;

//    //Player��Rigidbody
//    private Rigidbody rb = null;

//    //�d�͌��ƂȂ�f��
//    private GameObject Planet;

//    //�uPlanet�v�^�O�����Ă���I�u�W�F�N�g���i�[����z��
//    private GameObject[] Planets;

//    //�d�͂̋���
//    public float Gravity;

//    //�f���ɑ΂���Player�̌���
//    private Vector3 Direction;

//    //Ray���ڐG�����f���̃|���S���̖@��
//    private Vector3 Normal_vec = new Vector3(0, 0, 0);


//    //�����ō����
//    int gravityDir = 1;  //1�̓I�u�W�F�N�g�̒��S�����ɁA-1�̓I�u�W�F�N�g�̒��S�̔��΂̕�����

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        rb.constraints = RigidbodyConstraints.FreezeRotation;
//        rb.useGravity = false;
//        myTransform = transform;

//        Planet = Choose_Planet();
//    }

//    void Update()
//    {
//        Attract();
//        RayTest();

//        if(reverseMesh != null)
//        {
//            if((transform.position - Planet.transform.position).magnitude < Planet.transform.localScale.x / 2)
//            {
//                gravityDir = -1;
//            }
//            else
//            {
//                gravityDir = 1;
//            }
//        }
//    }
    

//    GameObject Choose_Planet()
//    {
//        Planets = GameObject.FindGameObjectsWithTag("Planet");

//        double[] Planet_distance = new double[Planets.Length];

//        for (int i = 0; i < Planets.Length; i++)
//        {
//            Planet_distance[i] = Vector3.Distance(transform.position, Planets[i].transform.position);
//        }

//        int min_index = 0;
//        double min_distance = Mathf.Infinity;

//        for (int j = 0; j < Planets.Length; j++)
//        {
//            if (Planet_distance[j] < min_distance)
//            {
//                min_distance = Planet_distance[j];
//                min_index = j;
//            }
//        }

//        return Planets[min_index];
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if(other.tag == "GravityArea")
//        {
//            Planet = other.transform.root.gameObject;
//            try
//            {
//                reverseMesh = Planet.GetComponent<ReverseMesh>();
//            }
//            catch
//            {
//                reverseMesh = null;
//            }
//        }
//    }

//    public void Attract()
//    {
//        Vector3 gravityUp = Normal_vec;

//        Vector3 bodyUp = myTransform.up;

//        myTransform.GetComponent<Rigidbody>().AddForce(gravityUp * Gravity * gravityDir);

//        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * myTransform.rotation;

//        myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRotation, 120 * Time.deltaTime);

//    }

//    void RayTest()
//    {
//        Direction = Planet.transform.position - transform.position;

//        Ray ray = new Ray(transform.position, Direction);

//        //Ray�����������I�u�W�F�N�g�̏������锠
//        RaycastHit hit;

//        //����Ray�ɃI�u�W�F�N�g���Փ˂�����
//        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
//        {
//            //Ray�����������I�u�W�F�N�g��tag��Planet��������
//            if (hit.collider.tag == "Planet")
//            {
//                Normal_vec = hit.normal;
//                //Planet = hit.transform.gameObject;
//            }
//        }
//    }
//}