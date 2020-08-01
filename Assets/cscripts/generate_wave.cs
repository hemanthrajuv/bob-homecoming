using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

using UnityEngine.SceneManagement;

public class generate_wave : MonoBehaviour
{
    int i = 0, j = 0;
    float k=10,t=0;
    float wait_timef = 3*(float)Math.PI;
    float portTime = 1;
    public float radius=10;
    float offset = 0,height=0, heightf = 0;
    public Camera start_cam;
    //int[] block2;
    //int[] path2;
    public GameObject c;
    public GameObject map;
    public GameObject finised;
    GameObject[] cubes;
    GameObject[] cubes2;
    GameObject[] cubesCompoundL;
    GameObject[] cubesCompoundR;
    GameObject[] cubesCompoundU;
    GameObject[] cubesCompoundD;
    GameObject[] portL;
    GameObject[,] portD;
    GameObject[,] portDp;
    GameObject[] portR;
    GameObject[] portal1;
    GameObject[] portal2;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    public Material pmat1;
    public Material pmat2;
    public Material Lpmat1;
    public Material Lpmat2;
    public GameObject center;
    public Material ma1;
    public Material ma2;
    public GameObject l0;
    public GameObject eg;
    Boolean[] level;
    public GameObject player;
    public GameObject princess;
    public Camera port1;
    public Material sb;
    public void setPlayer(GameObject pl)
    {
        player = pl;
    }
    void createPortL() {
        MeshRenderer mr;
        portL = new GameObject[3];
        portL[0] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mr = portL[0].GetComponent<MeshRenderer>();
        mr.material = mat4;
        portL[0].name = "portLM";
        portL[1] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mr = portL[1].GetComponent<MeshRenderer>();
        mr.material = mat4;
        portL[1].name = "portLL";
        portL[2] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mr = portL[2].GetComponent<MeshRenderer>();
        mr.material = mat4;
        portL[2].name = "portLR";
        portL[0].transform.localScale = new Vector3(1f, .25f, .35f);
        portL[0].transform.parent = center.transform;
        portL[0].transform.localPosition = new Vector3(7.5f, -2.5f, 0);
        portL[1].transform.localScale = new Vector3(.125f, 1.25f, .25f);
        portL[1].transform.parent = center.transform;
        portL[1].transform.localPosition = new Vector3(6.7f, -1.25f, 0);
        portL[2].transform.localScale = new Vector3(.125f, 1.25f, .25f);
        portL[2].transform.parent = center.transform;
        portL[2].transform.localPosition = new Vector3(8.3f, -1.25f, 0);
    }
    void createDummyPort()
    {
        portD = new GameObject[4,40];
        portDp = new GameObject[4, 50];
        i = 0;
        for (float inx = 0; inx > -10; inx -= 0.25f)
        {
            MeshRenderer mr;
            portD[0, i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            portD[0, i].name = "portDM"+i;
            //portD[0, i].layer = 9;
            portD[3, i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            portD[3, i].name = "portDD"+i;
            portD[1, i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            portDp[1, i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            portD[1, i].name = "portDL" + i;
            portDp[1, i].name = "portDL" + i;
            //portD[1, i].layer = 9;
            portD[2, i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            portDp[2, i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            portD[2, i].name = "portDR" + i;
            portDp[2, i].name = "portDR" + i;
            if (i % 2 != 0)
            {
                portD[3, i].layer = 9;
                mr = portD[0, i].GetComponent<MeshRenderer>();
                mr.material = ma1;
                mr = portDp[1, i].GetComponent<MeshRenderer>();
                mr.material = ma2;
                mr = portDp[2, i].GetComponent<MeshRenderer>();
                mr.material = ma2;
                mr = portD[3, i].GetComponent<MeshRenderer>();
                mr.material = ma2;
            }
            else
            {
                mr = portD[0, i].GetComponent<MeshRenderer>();
                mr.material = ma2;
                mr = portDp[1, i].GetComponent<MeshRenderer>();
                mr.material = ma1;
                mr = portDp[2, i].GetComponent<MeshRenderer>();
                mr.material = ma1;
                mr = portD[3, i].GetComponent<MeshRenderer>();
                mr.material = ma1;
            }

            //portD[2, i].layer = 9;
            portD[0, i].transform.localScale = new Vector3(1f, .25f, .25f);
            portD[0, i].transform.parent = center.transform;
            portD[0, i].transform.localPosition = new Vector3(7.5f, -2.5f+inx, inx);
            portD[3, i].transform.localScale = new Vector3(1f, .25f, .25f);
            portD[3, i].transform.parent = center.transform;
            portD[3, i].transform.localPosition = new Vector3(7.5f, -0.05f+inx, inx);
            portD[1, i].transform.localScale = new Vector3(.025f, 0.01f, .125f);
            portDp[1, i].transform.localScale = new Vector3(.125f, 1.25f, .125f);
            portD[1, i].transform.parent = center.transform;
            portDp[1, i].transform.parent = portD[1, i].transform;
            portD[1, i].transform.localPosition = new Vector3(6.7f, -1.25f+inx, inx);
            portDp[1, i].transform.localPosition = new Vector3(0, 60f,0);
            portD[2, i].transform.localScale = new Vector3(.025f, 0.01f, .125f);
            portDp[2, i].transform.localScale = new Vector3(.125f, 1.25f, .125f);
            portD[2, i].transform.parent = center.transform;
            portDp[2, i].transform.parent = portD[2, i].transform;
            portD[2, i].transform.localPosition = new Vector3(8.3f, -1.25f+inx, inx);
            portDp[2, i].transform.localPosition = new Vector3(0, 60f, 0);
            i++;
        }
        port1.transform.parent = center.transform;
        port1.transform.localPosition = new Vector3(7.5f, -2.5f, -0.8f);
    }
    void createPortR()
    {
        MeshRenderer mr;
        portR = new GameObject[3];
        portR[0] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mr = portR[0].GetComponent<MeshRenderer>();
        mr.material = mat4;
        portR[0].name = "portRM";
        portR[1] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mr = portR[1].GetComponent<MeshRenderer>();
        mr.material = mat4;
        portR[1].name = "portRL";
        portR[2] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mr = portR[2].GetComponent<MeshRenderer>();
        mr.material = mat4;
        portR[2].name = "portRR";
        portR[0].transform.localScale = new Vector3(1f, .25f, .35f);
        portR[0].transform.parent = center.transform;
        portR[0].transform.localPosition = new Vector3(-7.5f, -2.5f, 0);
        portR[1].transform.localScale = new Vector3(.125f, 1.25f, .25f);
        portR[1].transform.parent = center.transform;
        portR[1].transform.localPosition = new Vector3(-6.7f, -1.25f, 0);
        portR[2].transform.localScale = new Vector3(.125f, 1.25f, .25f);
        portR[2].transform.parent = center.transform;
        portR[2].transform.localPosition = new Vector3(-8.3f, -1.25f, 0);
    }
    void createSurface() {
        i = 0;
        cubes = new GameObject[19 * 19 * 20];
        for (float x = -9.5f; x <= 9.5f; x += .25f)
        {
            for (float z = -9.5f; z <= 9.5f; z += .25f)
            {
                i++;
                cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubes[i].name = "cube" + i;
                if (mat1 != null)
                {
                    MeshRenderer mr = cubes[i].GetComponent<MeshRenderer>();
                    mr.material = mat1;
                }
                cubes[i].transform.localScale = new Vector3(.125f, .125f, .125f);
                cubes[i].transform.parent = center.transform;
                cubes[i].transform.localPosition = new Vector3(x, 0, z);
            }
        }
    }
    void createCompound() {
        cubesCompoundL = new GameObject[21];
        cubesCompoundR = new GameObject[21];
        cubesCompoundU = new GameObject[21];
        cubesCompoundD = new GameObject[21];
        MeshRenderer mr;
        float temp = 10.5f;
        for (int i = 0; i < 21; i++)
        {
            cubesCompoundL[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            mr = cubesCompoundL[i].GetComponent<MeshRenderer>();
            mr.material = mat4;
            cubesCompoundL[i].name = "cubeL" + i;
            cubesCompoundL[i].transform.localScale = new Vector3(.9f, .9f, .9f);
            cubesCompoundL[i].transform.parent = center.transform;
            cubesCompoundL[i].transform.localPosition = new Vector3(-10.5f, 0, temp);
            temp--;
        }
        temp = 10.5f;
        for (int i = 0; i < 21; i++)
        {
            cubesCompoundR[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            mr = cubesCompoundR[i].GetComponent<MeshRenderer>();
            mr.material = mat4;
            cubesCompoundR[i].name = "cubeR" + i;
            cubesCompoundR[i].transform.localScale = new Vector3(.9f, .9f, .9f);
            cubesCompoundR[i].transform.parent = center.transform;
            cubesCompoundR[i].transform.localPosition = new Vector3(10.5f, 0, temp);
            temp--;
        }
        temp = 10.5f;
        for (int i = 0; i < 21; i++)
        {
            cubesCompoundU[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            mr = cubesCompoundU[i].GetComponent<MeshRenderer>();
            mr.material = mat4;
            cubesCompoundU[i].name = "cubeU" + i;
            cubesCompoundU[i].transform.localScale = new Vector3(.9f, .9f, .9f);
            cubesCompoundU[i].transform.parent = center.transform;
            cubesCompoundU[i].transform.localPosition = new Vector3(temp, 0, -10.5f);
            temp--;
        }

        temp = 10.5f;
        for (int i = 0; i < 21; i++)
        {
            cubesCompoundD[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            mr = cubesCompoundD[i].GetComponent<MeshRenderer>();
            mr.material = mat4;
            cubesCompoundD[i].name = "cubeD" + i;
            cubesCompoundD[i].transform.localScale = new Vector3(.9f, .9f, .9f);
            cubesCompoundD[i].transform.parent = center.transform;
            cubesCompoundD[i].transform.localPosition = new Vector3(temp, 0, 10.5f);
            temp--;
        }
    }
    void createPortals()
    {
        MeshRenderer mr;MeshCollider mc;
        portal1 = new GameObject[3];
        portal2 = new GameObject[3];
        portal1[0] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        mr = portal1[0].GetComponent<MeshRenderer>();
        mr.material = pmat1;
        portal1[2] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        mr = portal1[2].GetComponent<MeshRenderer>();
        mr.material = Lpmat1;
        portal2[2] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        mr = portal2[2].GetComponent<MeshRenderer>();
        mr.material = Lpmat2;
        portal1[1] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        mr = portal1[1].GetComponent<MeshRenderer>();
        mr.material = pmat2;
        portal2[0] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        mr = portal2[0].GetComponent<MeshRenderer>();
        mr.material = pmat1;
        portal2[1] = GameObject.CreatePrimitive(PrimitiveType.Plane);
        mr = portal2[1].GetComponent<MeshRenderer>();
        mr.material = pmat2;
        portal1[0].name = "portallu";
        portal1[1].name = "portalld";
        portal1[2].name = "portall2";
        portal2[0].name = "portalru";
        portal2[1].name = "portalrd";
        portal2[2].name = "portalr2";
        mc = portal1[0].GetComponent<MeshCollider>();
        mc.convex = true;
        mc.isTrigger = true;
        mc = portal2[0].GetComponent<MeshCollider>();
        mc.convex = true;
        mc.isTrigger = true;
        mc = portal1[1].GetComponent<MeshCollider>();
        mc.convex = true;
        mc.isTrigger = true;
        mc = portal1[2].GetComponent<MeshCollider>();
        mc.convex = true;
        mc.isTrigger = true;
        mc = portal2[1].GetComponent<MeshCollider>();
        mc.convex = true;
        mc.isTrigger = true;
        mc = portal2[2].GetComponent<MeshCollider>();
        mc.convex = true;
        //mc.isTrigger = true;
        portal1[0].AddComponent<portals>();
        portal2[0].AddComponent<portals>();
        portal1[1].AddComponent<portals>();
        portal2[1].AddComponent<portals>();
        portal1[2].AddComponent<portals>();
        portal2[2].AddComponent<portals>();
        portal1[0].transform.parent = center.transform;
        portal1[0].transform.localScale = new Vector3(0.15f, 0f, 0.23f);
        portal1[0].transform.Rotate(new Vector3(90, 0, 0));
        portal1[0].transform.localPosition = new Vector3(7.5f, 1.5f, 0);
        portal1[1].transform.parent = center.transform;
        portal1[1].transform.localScale = new Vector3(0.15f, 0f, 0.23f);
        portal1[1].transform.Rotate(new Vector3(90, 180, 0));
        portal1[1].transform.localPosition = new Vector3(7.5f, -1.5f, 0);
        portal1[2].transform.parent = center.transform;
        portal1[2].transform.Rotate(new Vector3(90, 0, 0));
        portal1[2].transform.localScale = new Vector3(0.15f, 0.01f, 0.23f);
        portal1[2].transform.localPosition = new Vector3(7.5f, 10.6f, -9.5f);
        portal2[0].transform.parent = center.transform;
        portal2[0].transform.Rotate(new Vector3(90, 0, 0));
        portal2[0].transform.localScale = new Vector3(0.15f, 0f, 0.23f);
        portal2[0].transform.localPosition = new Vector3(-7.5f, 1.5f, 0);
        portal2[1].transform.parent = center.transform;
        portal2[1].transform.Rotate(new Vector3(90, 180, 0));
        portal2[1].transform.localScale = new Vector3(0.15f, 0f, 0.23f);
        portal2[1].transform.localPosition = new Vector3(-7.5f, -1.5f, 0);
        portal2[2].transform.parent = center.transform;
        portal2[2].transform.Rotate(new Vector3(90, 0, 0));
        portal2[2].transform.localScale = new Vector3(0.15f, 0.01f, 0.23f);
        portal2[2].transform.localPosition = new Vector3(-7.5f, 10.7f, -9.5f);
        portal1[1].SetActive(false);
        portal2[1].SetActive(false);
        portal1[2].SetActive(false);
        portal2[2].SetActive(false);
    }
    void Start()
    {
        RenderSettings.skybox = sb;
        i = 0;
        level = new Boolean[3];
        level[0] = false;level[1] = false;level[2] = false;
        start_cam.transform.parent = center.transform;
        //createPortL();
        //createPortR();
        //createDummyPort();
        createSurface();
        createCompound();
        //player.SetActive(false);
        //createPortals();
        //create_maze();
        //player.transform.parent = center.transform;
        //Physics.IgnoreLayerCollision(0, 9);
    }
    public void start_game()
    {
        Time.timeScale = 1f;
        level[0] = true;
        createPortL();
        createPortR();
        createDummyPort();
        createPortals();
        create_maze();
        player.transform.position = new Vector3(0, 2, 0);
        player.SetActive(true);
        start_cam.enabled = false;
    }
    void surfaceWave1() {
        i = 0;
        float y = 0.125f;
        int[] block2 = new int[] { 5749, 5518, 5191, 4960, 4665, 4511, 4186, 3955, 2320, 2323,
            3330,3328,2490,2487,737,968,1423,1269,1738,1969,3687,3684,2525,2523,3289,3286};
        for (float x = -9.5f; x <= 9.5f; x += .25f)
        {
            for (float z = -9.5f; z <= 9.5f; z += .25f)
            {
                i++;
                float distance = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(cubes[i].transform.position.x, 0, cubes[i].transform.position.z));
                Mathf.Clamp(distance, 1, 3);
                    if (distance > 1.5f && level[0])
                    {
                        //cubes[i].transform.localPosition = new Vector3(cubes[i].transform.localPosition.x, (distance * 0.5f) - 0.5f, cubes[i].transform.localPosition.z);
                        cubes[i].transform.localScale = new Vector3(0.25f, y + (float)Math.Sin(distance * 2) * 2, 0.25f);
                    }
                    else
                    {
                        cubes[i].transform.localScale = new Vector3(.2f, .125f, .2f);
                    }
                    if (level[1])
                    {
                        if (block2.Any(iot => iot == i)) {
                            cubes[i].transform.localPosition = new Vector3(cubes[i].transform.localPosition.x, 0.7f, cubes[i].transform.localPosition.z);
                            cubes[i].transform.localScale = new Vector3(.7f, 1.7f, .7f);
                        }
                    }
                
                if (cubes[i].transform.localScale.y > 0.25)
                {
                    if (mat1 != null)
                    {
                        MeshRenderer mr = cubes[i].GetComponent<MeshRenderer>();
                        mr.material = mat1;
                    }
                }
                else
                {
                    if (mat2 != null)
                    {
                        MeshRenderer mr = cubes[i].GetComponent<MeshRenderer>();
                        mr.material = mat2;
                    }
                }
            }
        }
    }
    void surfaceWave()
    {
        i = 0;
        float y = 0.125f;
        if (k >= 20) {
            k = 10;
        }
        if (t > Math.PI * 2)
        {
            t = 0;
        }
        start_cam.transform.position = new Vector3((float)Math.Cos(t) * radius, 5, (float)Math.Sin(t) * radius);
        start_cam.transform.LookAt(princess.transform);
        for (float x = -9.5f; x <= 9.5f; x += .25f)
        {
            for (float z = -9.5f; z <= 9.5f; z += .25f)
            {
                i++;
                float distance = Vector3.Distance(new Vector3(princess.transform.position.x, 0, princess.transform.position.z), new Vector3(cubes[i].transform.position.x, 0, cubes[i].transform.position.z));
                Mathf.Clamp(distance, 1, 3);
                    //cubes[i].transform.localPosition = new Vector3(cubes[i].transform.localPosition.x, (distance * 0.5f) - 0.5f, cubes[i].transform.localPosition.z);
                    cubes[i].transform.localScale = new Vector3(0.25f, y + (float)Math.Sin((distance+k) * 2) * 2, .25f);

                if (cubes[i].transform.localScale.y > 0.25)
                {
                    if (mat1 != null)
                    {
                        MeshRenderer mr = cubes[i].GetComponent<MeshRenderer>();
                        mr.material = mat1;
                    }
                }
                else
                {
                    if (mat2 != null)
                    {
                        MeshRenderer mr = cubes[i].GetComponent<MeshRenderer>();
                        mr.material = mat2;
                    }
                }
            }
        }
        k+=0.01f;
        t += 0.01f;
    }
    void compoundWave1() {
        i = 0;
        int h = 2;
        if (level[1])
        {
            h = 5;
        }
        if (heightf >= 2 * Math.PI)
        {
            heightf = 0;
        }
        height = (float)Math.Cos(heightf) + 1;
        heightf += Time.deltaTime * 3.3f;/*
        cubesCompoundD[11].transform.localScale = new Vector3(.9f, height, .9f);
        cubesCompoundU[11].transform.localScale = new Vector3(.9f, height, .9f);
        cubesCompoundR[11].transform.localScale = new Vector3(.9f, height, .9f);
        cubesCompoundL[11].transform.localScale = new Vector3(.9f, height, .9f);*/
        for (int idx = 0; idx < 21; idx++)
        {
            if (idx == 221)
                continue;
            else
            {
                float distance = Vector3.Distance(new Vector3(0, 0, 0.5f), new Vector3(0, 0, cubesCompoundL[idx].transform.position.z));
                cubesCompoundL[idx].transform.localScale = new Vector3(.9f, (float)Math.Cos(heightf + distance) + h, .9f);
            }
        }
        for (int idx = 0; idx < 21; idx++)
        {
            if (idx == 112)
                continue;
            else
            {
                float distance = Vector3.Distance(new Vector3(0, 0, 0.5f), new Vector3(0, 0, cubesCompoundR[idx].transform.position.z));
                cubesCompoundR[idx].transform.localScale = new Vector3(.9f, (float)Math.Cos(heightf + distance) + h, .9f);
            }
        }
        for (int idx = 0; idx < 21; idx++)
        {
            if (idx == 118)
                continue;
            else
            {
                float distance = Vector3.Distance(new Vector3(0.5f, 0, 0), new Vector3(cubesCompoundU[idx].transform.position.x, 0, 0));
                cubesCompoundU[idx].transform.localScale = new Vector3(.9f, (float)Math.Cos(heightf + distance) + h, .9f);
            }
        }
        for (int idx = 0; idx < 21; idx++)
        {
            if (idx == 111)
                continue;
            else
            {
                float distance = Vector3.Distance(new Vector3(0.5f, 0, 0), new Vector3(cubesCompoundD[idx].transform.position.x, 0, 0));
                cubesCompoundD[idx].transform.localScale = new Vector3(.9f, (float)Math.Cos(heightf + distance) + h, .9f);
            }
        }
    }
    void updatePort()
    {
        float distance1 = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(portL[0].transform.position.x, 0, portL[0].transform.position.z));
        int pos1 = -1;
        if (distance1 < 1.5)
        {
            pos1 = 1;
        }
            portL[2].transform.localPosition = new Vector3(8.3f, pos1*1.25f, 0);
            portL[1].transform.localPosition = new Vector3(6.7f, pos1*1.25f, 0);
            portL[0].transform.localPosition = new Vector3(7.5f, pos1*2.5f, 0);
            portal1[0].transform.localPosition = new Vector3(7.5f, pos1 * 1.25f, -0.25f);
            portal1[1].transform.localPosition = new Vector3(7.5f, pos1 * 1.25f, 0.25f);
        float distance2 = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(portR[0].transform.position.x, 0, portR[0].transform.position.z));
        int pos2 = -1;
        if (distance2 < 1.5)
        {
            pos2 = 1;
        }
        portR[2].transform.localPosition = new Vector3(-8.3f, pos2 * 1.25f, 0);
        portR[1].transform.localPosition = new Vector3(-6.7f, pos2 * 1.25f, 0);
        portR[0].transform.localPosition = new Vector3(-7.5f, pos2 * 2.5f, 0);
        portal2[0].transform.localPosition = new Vector3(-7.5f, pos2 * 1.25f, -0.25f);
        portal2[1].transform.localPosition = new Vector3(-7.5f, pos2 * 1.25f, 0.25f);
    }
    void create_maze()
    {
        cubes2 = new GameObject[1024];
        i = 0;
        j = 0;
        float x, y;
        //cubes[i].transform.localScale = new Vector3(.125f, .125f, .125f);
        int[] path2 = new int[] { 64, 513, 318, 483, 421, 619, 744, 595, 667, 759, 867, 821, 857, 975, 1008 };
        for (float ind = 9.5f; ind >= 1; ind -= 1.7f)
        {
            y = -ind;
            for (x = -ind; x <= ind; x += 0.25f)
            {
                cubes2[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubes2[i].name = "cube2" + i;
                if (mat3 != null)
                {
                    MeshRenderer mr = cubes2[i].GetComponent<MeshRenderer>();
                    mr.material = mat3;
                }
                cubes2[i].transform.parent = center.transform;
                if (path2.Any(iot =>  iot == i||(iot+1 )==i)|| path2.Any(iot => (iot+2) == i || (iot + 3) == i))
                {
                    cubes2[i].transform.localPosition = new Vector3(x, -1f, y);
                    cubes2[i].transform.localScale = new Vector3(.01f, 0.01f, .01f);
                }
                else
                {
                    cubes2[i].transform.localPosition = new Vector3(x, .7f, y);
                    cubes2[i].transform.localScale = new Vector3(.25f, 1.2f, .25f);
                }
                i++;
            }
            y = +ind;
            for (x = -ind; x <= ind; x += 0.25f)
            {
                cubes2[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubes2[i].name = "cube2" + i;
                if (mat3 != null)
                {
                    MeshRenderer mr = cubes2[i].GetComponent<MeshRenderer>();
                    mr.material = mat3;
                }
                cubes2[i].transform.parent = center.transform;
                if (path2.Any(iot => iot == i || (iot + 1) == i) || path2.Any(iot => (iot + 2) == i || (iot + 3) == i))
                {
                    cubes2[i].transform.localPosition = new Vector3(x, -1f, y);
                    cubes2[i].transform.localScale = new Vector3(.01f, 0.01f, .01f);
                }
                else
                {
                    cubes2[i].transform.localPosition = new Vector3(x, .7f, y);
                    cubes2[i].transform.localScale = new Vector3(.25f, 1.2f, .25f);
                }
                i++;
            }
            x = -ind;
            for (y = -ind; y <= ind; y += 0.25f)
            {
                cubes2[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubes2[i].name = "cube2" + i;
                if (mat3 != null)
                {
                    MeshRenderer mr = cubes2[i].GetComponent<MeshRenderer>();
                    mr.material = mat3;
                }
                cubes2[i].transform.parent = center.transform;
                if (path2.Any(iot => iot == i || (iot + 1) == i) || path2.Any(iot => (iot + 2) == i || (iot + 3) == i))
                {
                    cubes2[i].transform.localPosition = new Vector3(x, -1f, y);
                    cubes2[i].transform.localScale = new Vector3(.01f, 0.01f, .01f);
                }
                else
                {
                    cubes2[i].transform.localPosition = new Vector3(x, .7f, y);
                    cubes2[i].transform.localScale = new Vector3(.25f, 1.2f, .25f);
                }
                i++;
            }
            x = +ind;
            for (y = -ind;y <= ind; y += 0.25f)
            {
                cubes2[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubes2[i].name = "cube2" + i;
                if (mat3 != null)
                {
                    MeshRenderer mr = cubes2[i].GetComponent<MeshRenderer>();
                    mr.material = mat3;
                }
                cubes2[i].transform.parent = center.transform;
                if (path2.Any(iot => iot == i || (iot + 1) == i) || path2.Any(iot => (iot + 2) == i || (iot + 3) == i))
                {
                    cubes2[i].transform.localPosition = new Vector3(x, -1f, y);
                    cubes2[i].transform.localScale = new Vector3(.01f, 0.01f, .01f);
                }
                else
                {
                    cubes2[i].transform.localPosition = new Vector3(x, .7f, y);
                    cubes2[i].transform.localScale = new Vector3(.25f, 1.2f, .25f);
                }
                i++;
            }
            j++;
        }
        //checkPath();

    }
    public void showStep(int a)
    {
        switch (a)
        {
            case 1:
                i = 0;
                for (float inx = 0; inx < 10; inx += 0.25f)
                {

                    if (i >= 38)
                        portD[0, i].transform.localPosition = new Vector3(7.5f, 2.5f + inx, -inx);
                    portD[1, i].transform.localPosition = new Vector3(8.3f, -0.05f + inx, -inx);
                    portD[2, i].transform.localPosition = new Vector3(6.7f, -0.05f + inx, -inx);
                    portD[3, i].transform.localPosition = new Vector3(7.5f, -0.05f + inx, -inx);
                    i++;
                }
                portal1[0].SetActive(false);
                portal2[0].SetActive(false);
                portal1[1].SetActive(true);
                portal2[1].SetActive(true);
                portal1[2].SetActive(true);
                portal2[2].SetActive(true);
                break;
            case 2:
                i = 0;
                for (float inx = 0; inx > -10; inx -= 0.25f)
                {

                    if (i >= 38)
                        portD[0, i].transform.localPosition = new Vector3(7.5f, -2.5f + inx, inx);
                    portD[1, i].transform.localPosition = new Vector3(8.3f, -0.05f + inx, inx);
                    portD[2, i].transform.localPosition = new Vector3(6.7f, -0.05f + inx, inx);
                    portD[3, i].transform.localPosition = new Vector3(7.5f, -0.05f + inx, inx);
                    i++;
                }
                portal1[2].SetActive(false);
                portal2[2].SetActive(false);
                portal1[1].SetActive(false);
                portal2[1].SetActive(false);
                portal1[0].SetActive(true);
                portal2[0].SetActive(true);
                break;
            case 3:
                i = 0;
                for (float inx = 0; inx < 10; inx += 0.25f)
                {

                    if (i >= 38)
                        portD[0, i].transform.localPosition = new Vector3(-7.5f, 2.5f + inx, -inx);
                    portD[1, i].transform.localPosition = new Vector3(-8.3f, -0.05f + inx, -inx);
                    portD[2, i].transform.localPosition = new Vector3(-6.7f, -0.05f + inx, -inx);
                    portD[3, i].transform.localPosition = new Vector3(-7.5f, -0.05f + inx, -inx);
                    i++;
                }
                portal1[0].SetActive(false);
                portal2[0].SetActive(false);
                portal1[1].SetActive(true);
                portal2[1].SetActive(true);
                portal1[2].SetActive(true);
                portal2[2].SetActive(true);
                break;
            case 4:
                i = 0;
                for (float inx = 0; inx > -10; inx -= 0.25f)
                {

                    if (i >= 38)
                        portD[0, i].transform.localPosition = new Vector3(7.5f, -2.5f + inx, inx);
                    portD[1, i].transform.localPosition = new Vector3(8.3f, -1.25f + inx, inx);
                    portD[2, i].transform.localPosition = new Vector3(6.7f, -1.25f + inx, inx);
                    portD[3, i].transform.localPosition = new Vector3(7.5f, -0.05f + inx, inx);
                    i++;
                }
                portal1[2].SetActive(false);
                portal2[2].SetActive(false);
                portal1[1].SetActive(false);
                portal2[1].SetActive(false);
                portal1[0].SetActive(true);
                portal2[0].SetActive(true);
                break;
            case 5:
                level[0] = false;level[1] = true;
                break;
            case 6:
                eg.SetActive(true);
                Time.timeScale = 0;
                break;
        }
        
    }
    void stepUpdate()
    {
        i = 0;
        for (float inx = 0; inx < 10; inx += 0.25f)
        {
            float distance = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(portD[3, i].transform.position.x, 0, portD[3, i].transform.position.z));
            if (distance*2 < Math.PI / 2)
            {
                portD[1, i].transform.localScale = new Vector3(0.025f, ((float)Math.Cos(distance*2) + 1.125f)/100f, 0.125f);
                portD[2, i].transform.localScale = new Vector3(.025f, ((float)Math.Cos(distance*2) + 1.125f)/100f, .125f);
            }
            else
            {
                portD[1, i].transform.localScale = new Vector3(.025f, 0.01f, .125f);
                portD[2, i].transform.localScale = new Vector3(.025f, 0.01f, .125f);

            }
            i++;
        }
    }
    void ActivateL0()
    {
        l0.SetActive(true);
        princess.SetActive(false);
        i = 0;
        j = 0;
        float x, y;
        //cubes[i].transform.localScale = new Vector3(.125f, .125f, .125f);
        for (float ind = 9.5f; ind >= 1; ind -= 1.7f)
        {
            y = -ind;
            for (x = -ind; x <= ind; x += 0.25f)
            {
                cubes2[i].SetActive(false);
                i++;
            }
            y = +ind;
            for (x = -ind; x <= ind; x += 0.25f)
            {
                cubes2[i].SetActive(false);
                i++;
            }
            x = -ind;
            for (y = -ind; y <= ind; y += 0.25f)
            {
                cubes2[i].SetActive(false);
                i++;
            }
            x = +ind;
            for (y = -ind; y <= ind; y += 0.25f)
            {
                cubes2[i].SetActive(false);
                i++;
            }
            j++;
        }
    }
    void ActivateL1() {
        princess.SetActive(true);
        map.SetActive(true);
        l0.SetActive(false);
        int[] path2 = new int[] { 64, 513, 318, 483, 421, 619, 744, 595, 667, 759, 867, 821, 857, 975, 1008 };
        for (int ind1 = 0; ind1 < 4; ind1++)
        {
            for (int ind2 = 0; ind2 < 40; ind2++)
            {
                portD[ind1, ind2].SetActive(false);
            }
        }
        for (int ind = 0; ind < 3; ind++)
        {
            portL[ind].SetActive(false);
            portR[ind].SetActive(false);
            portal1[ind].SetActive(false);
            portal2[ind].SetActive(false);
        }
        i = 0;
        j = 0;
        float x, y;
        //cubes[i].transform.localScale = new Vector3(.125f, .125f, .125f);
        for (float ind = 9.5f; ind >= 1; ind -= 1.7f)
        {
            y = -ind;
            for (x = -ind; x <= ind; x += 0.25f)
            {
                cubes2[i].SetActive(true);
                float distance = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(cubes2[i].transform.position.x, 0, cubes2[i].transform.position.z));
                if (path2.Any(iot => iot == i || (iot + 1) == i) || path2.Any(iot => (iot + 2) == i || (iot + 3) == i))
                {
                    cubes2[i].transform.localPosition = new Vector3(x, -1f, y);
                    cubes2[i].transform.localScale = new Vector3(.01f, 0.01f, .01f);
                }
                else
                {
                    if (distance < Math.PI / 2.5)
                    {
                        cubes2[i].transform.localScale = new Vector3(cubes2[i].transform.localScale.x, 2f + (float)Math.Cos(distance * 2.5), cubes2[i].transform.localScale.z);
                    }
                    else
                    {
                        cubes2[i].transform.localScale = new Vector3(.25f, 1f, .25f);
                    }
                }
                i++;
            }
            y = +ind;
            for (x = -ind; x <= ind; x += 0.25f)
            {
                cubes2[i].SetActive(true);
                float distance = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(cubes2[i].transform.position.x, 0, cubes2[i].transform.position.z));
                if (path2.Any(iot => iot == i || (iot + 1) == i) || path2.Any(iot => (iot + 2) == i || (iot + 3) == i))
                {
                    cubes2[i].transform.localPosition = new Vector3(x, -1f, y);
                    cubes2[i].transform.localScale = new Vector3(.01f, 0.01f, .01f);
                }
                else
                {
                    if (distance < Math.PI / 2.5)
                    {
                        cubes2[i].transform.localScale = new Vector3(cubes2[i].transform.localScale.x, 2f + (float)Math.Cos(distance * 2.5), cubes2[i].transform.localScale.z);
                    }
                    else
                    {
                        cubes2[i].transform.localScale = new Vector3(.25f, 1f, .25f);
                    }
                }
                i++;
            }
            x = -ind;
            for (y = -ind; y <= ind; y += 0.25f)
            {
                cubes2[i].SetActive(true);
                float distance = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(cubes2[i].transform.position.x, 0, cubes2[i].transform.position.z));
                if (path2.Any(iot => iot == i || (iot + 1) == i) || path2.Any(iot => (iot + 2) == i || (iot + 3) == i))
                {
                    cubes2[i].transform.localPosition = new Vector3(x, -1f, y);
                    cubes2[i].transform.localScale = new Vector3(.01f, 0.01f, .01f);
                }
                else
                {
                    if (distance < Math.PI / 2.5)
                    {
                        cubes2[i].transform.localScale = new Vector3(cubes2[i].transform.localScale.x, 2f + (float)Math.Cos(distance * 2.5), cubes2[i].transform.localScale.z);
                    }
                    else
                    {
                        cubes2[i].transform.localScale = new Vector3(.25f, 1f, .25f);
                    }
                }
                i++;
            }
            x = +ind;
            for (y = -ind; y <= ind; y += 0.25f)
            {
                cubes2[i].SetActive(true);
                float distance = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(cubes2[i].transform.position.x, 0, cubes2[i].transform.position.z));
                if (path2.Any(iot => iot == i || (iot + 1) == i) || path2.Any(iot => (iot + 2) == i || (iot + 3) == i))
                {
                    cubes2[i].transform.localPosition = new Vector3(x, -1f, y);
                    cubes2[i].transform.localScale = new Vector3(.01f, 0.01f, .01f);
                }
                else
                {
                    if (distance < Math.PI/2.5)
                    {
                        cubes2[i].transform.localScale = new Vector3(cubes2[i].transform.localScale.x, 2f+ (float)Math.Cos(distance*2.5), cubes2[i].transform.localScale.z);
                    }
                    else
                    {
                        cubes2[i].transform.localScale = new Vector3(.25f, 1f, .25f);
                    }
                }
                i++;
            }
            j++;
        }
        /*i = 0;
        for (float x = -9.5f; x <= 9.5f; x += 0.25f)
        {
            for (float z = -9.5f; z <= 9.5f; z += 0.25f)
            {
                cubes[i].transform.localScale = new Vector3(.125f, .125f, .125f);
                //cubes[i].SetActive(false);
                i++;
                //cubes[i].transform.localScale = new Vector3(.125f, .125f, .125f);
                //if (mat3 != null)
                //{
                    //MeshRenderer mr = cubes[i].GetComponent<MeshRenderer>();
                  //  mr.material = mat3;
                //}
            }
        }*/
    }
    void ActivateL2() {
        map.SetActive(false);
        player.SetActive(false);
        finised.SetActive(true);
        start_cam.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        radius = 5;
        // Time.timeScale = 0f;
        if (wait_timef <= 0)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            if (wait_timef <= 1.5f*(float)Math.PI&& !finised.transform.Find("pi").gameObject.active)
            {
                finised.transform.Find("pi").gameObject.SetActive(true);
            }
            wait_timef -= Time.deltaTime;
        }
        start_cam.transform.position = new Vector3((float)Math.Cos(wait_timef) * radius, 5, (float)Math.Sin(wait_timef) * radius);
        start_cam.transform.LookAt(princess.transform);
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;

            c.SetActive(true);
        }
        if (level.All(fl => fl == false))
        {
            Debug.Log('k');
            surfaceWave();
            compoundWave1();
        }
    }
    void Update()
    {
        if (portTime >= 0)
        {
            portTime -= Time.deltaTime;
        }
        if (level[0])
            {
                ActivateL0();
                surfaceWave1();
                compoundWave1();
                updatePort();
            stepUpdate();
            }
            if (level[1])
            {
                surfaceWave1();
                compoundWave1();
                ActivateL1();
            float distance = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(center.transform.position.x, 0, center.transform.position.z));
            if (distance <= 0.7f)
            {
                level[1] = false;
                level[2] = true;
            }
            }
            if (level[2])
            {
                ActivateL2();
                //create_maze();
            }
        
    }
}
