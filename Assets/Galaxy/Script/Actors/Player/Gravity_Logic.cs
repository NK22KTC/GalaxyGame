//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Gravity_Logic : MonoBehaviour
//{
//    ReverseMesh reverseMesh;

//    //PlayerのTransform
//    private Transform myTransform;

//    //PlayerのRigidbody
//    private Rigidbody rb = null;

//    //重力減となる惑星
//    private GameObject Planet;

//    //「Planet」タグがついているオブジェクトを格納する配列
//    private GameObject[] Planets;

//    //重力の強さ
//    public float Gravity;

//    //惑星に対するPlayerの向き
//    private Vector3 Direction;

//    //Rayが接触した惑星のポリゴンの法線
//    private Vector3 Normal_vec = new Vector3(0, 0, 0);


//    //自分で作った
//    int gravityDir = 1;  //1はオブジェクトの中心方向に、-1はオブジェクトの中心の反対の方向に

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

//        //Rayが当たったオブジェクトの情報を入れる箱
//        RaycastHit hit;

//        //もしRayにオブジェクトが衝突したら
//        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
//        {
//            //Rayが当たったオブジェクトのtagがPlanetだったら
//            if (hit.collider.tag == "Planet")
//            {
//                Normal_vec = hit.normal;
//                //Planet = hit.transform.gameObject;
//            }
//        }
//    }
//}