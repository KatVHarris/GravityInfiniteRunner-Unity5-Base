using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestSpawner : MonoBehaviour
{

    public List<GameObject> PathPlatforms;
    public List<GameObject> NoPathPlatforms;

    public List<GameObject> PathBottomPlatforms;
    public List<GameObject> PathLeftPlatforms;
    public List<GameObject> PathTopPlatforms;
    public List<GameObject> PathRightPlatforms;


    public List<GameObject> NPBottomPlatforms;
    public List<GameObject> NPLeftPlatforms;
    public List<GameObject> NPTopPlatforms;
    public List<GameObject> NPRightPlatforms;


    public List<GameObject> activeBottomPlatforms;
    public List<GameObject> activeLeftPlatforms;
    public List<GameObject> activeTopPlatforms;
    public List<GameObject> activeRightPlatforms;

    GameObject startPlaneObject;

    private string bottomPlatformTag = "BottomPlatform";
    private string topPlatformTag = "TopPlatform";
    private string leftPlatformTag = "LeftPlatform";
    private string rightPlatformTag = "RightPlatform";

    public float leftPlatAdjustment = -3.5f;
    public float rightPlatAdjustment = 3.5f;
    public float topPlatAdjustment = 3f;
    public float botPlatAdjustment = -3f;

    bool beginning = false;
    bool gamestarted = false; 

    int difficulty = 2;
    // Use this for initialization
    void Awake()
    {
        startPlaneObject = GameObject.FindGameObjectWithTag("Beginning");
        gamestarted = false; 
    }

    public void StartGeneration()
    {
        gamestarted = true; 
        if (this.activeBottomPlatforms.Count == 0)
        {
            GameObject x = (GameObject)GameObject.Instantiate(this.PathBottomPlatforms[0], new Vector3(0, -3f, 0), Quaternion.identity);
            x.tag = bottomPlatformTag;
            //			x.gameObject.tag = "BottomPlatform";
            this.activeBottomPlatforms.Add(x);
        }
        if (this.activeLeftPlatforms.Count == 0)
        {
            Quaternion leftRotate = Quaternion.AngleAxis(90, Vector3.forward);
            GameObject x = (GameObject)GameObject.Instantiate(this.PathLeftPlatforms[0], new Vector3(-3f, 0f, 0), leftRotate);
            x.tag = leftPlatformTag;
            //			x.gameObject.tag = "LeftPlatform";
            this.activeLeftPlatforms.Add(x);
        }
        if (this.activeTopPlatforms.Count == 0)
        {
            Quaternion topRotate = Quaternion.AngleAxis(180, Vector3.forward);
            GameObject x = (GameObject)GameObject.Instantiate(this.PathTopPlatforms[0], new Vector3(0, 3f, 0), topRotate);
            //x.gameObject.tag = "TopPlatform";
            x.tag = topPlatformTag;
            this.activeTopPlatforms.Add(x);
        }
        if (this.activeRightPlatforms.Count == 0)
        {
            Quaternion rightRotate = Quaternion.AngleAxis(-90, Vector3.forward);
            GameObject x = (GameObject)GameObject.Instantiate(this.PathRightPlatforms[0], new Vector3(3f, 0, 0), rightRotate);
            //x.gameObject.tag = "RightPlatform";

            x.tag = rightPlatformTag;
            this.activeRightPlatforms.Add(x);
        }

        beginning = true;
        for (int i = 0; i < 2; i++)
        {
            GenerateSafePlatforms();
        }
        beginning = false;

        startPlaneObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestarted)
        {
            CreatePlatforms();
        }


    }

    void CreatePlatforms()
    {
        if (activeBottomPlatforms.Count < 8)
            this.GeneratePlatforms();


        if (activeLeftPlatforms.Count < 8)
            this.GeneratePlatforms();

        if (activeTopPlatforms.Count < 8)
            this.GeneratePlatforms();

        if (activeRightPlatforms.Count < 8)
            this.GeneratePlatforms();
    }

    public void RemoveBottomPlatform(GameObject gobj)
    {

        this.activeBottomPlatforms.Remove(gobj);
        GameObject.Destroy(gobj);

    }

    public void RemoveTopPlatform(GameObject gobj)
    {

        this.activeTopPlatforms.Remove(gobj);
        GameObject.Destroy(gobj);

    }
    public void RemoveLeftPlatform(GameObject gobj)
    {

        this.activeLeftPlatforms.Remove(gobj);
        GameObject.Destroy(gobj);

    }
    public void RemoveRightPlatform(GameObject gobj)
    {

        this.activeRightPlatforms.Remove(gobj);
        GameObject.Destroy(gobj);

    }

    public void StopMovement()
    {
        foreach (GameObject item in activeBottomPlatforms)
        {
            item.GetComponent<MoveBackwards>().enabled = false; 
        }

        foreach (GameObject item in activeLeftPlatforms)
        {
            item.GetComponent<MoveBackwards>().enabled = false;

        }


        foreach (GameObject item in activeRightPlatforms)
        {
            item.GetComponent<MoveBackwards>().enabled = false;

        }


        foreach (GameObject item in activeTopPlatforms)
        {
            item.GetComponent<MoveBackwards>().enabled = false;

        }
    }

    public void RemoveAll()
    {
        foreach(GameObject item in activeBottomPlatforms)
        {
            this.activeBottomPlatforms.Remove(item);
            Destroy(item);
        }

        foreach (GameObject item in activeLeftPlatforms)
        {
            this.activeBottomPlatforms.Remove(item);
            Destroy(item);
        }


        foreach (GameObject item in activeRightPlatforms)
        {
            this.activeBottomPlatforms.Remove(item);
            Destroy(item);
        }


        foreach (GameObject item in activeTopPlatforms)
        {
            this.activeBottomPlatforms.Remove(item);
            Destroy(item);
        }
    }

    void GenerateSafePlatforms()
    {

        
        Vector3 lastBotPlatPos = this.activeBottomPlatforms[this.activeBottomPlatforms.Count - 1].transform.position;
        Quaternion noRotate = this.activeBottomPlatforms[this.activeBottomPlatforms.Count - 1].transform.rotation; //Quaternion.identity;
        CreateBottom(true, bottomPlatformTag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);

        Vector3 lastLeftPlatPos = this.activeLeftPlatforms[this.activeLeftPlatforms.Count - 1].transform.position; ;
        Quaternion leftRotate = this.activeLeftPlatforms[this.activeLeftPlatforms.Count - 1].transform.rotation; ////Quaternion.AngleAxis (90, Vector3.forward);
        CreateLeft(true, leftPlatformTag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);

        Vector3 lastTopPlatPos = this.activeTopPlatforms[this.activeTopPlatforms.Count - 1].transform.position;
        Quaternion topRotate = this.activeTopPlatforms[this.activeTopPlatforms.Count - 1].transform.rotation; 
        CreateTop(true, topPlatformTag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);

        Vector3 lastRightPlatPos = this.activeRightPlatforms[this.activeRightPlatforms.Count - 1].transform.position;
        Quaternion rightRotate = this.activeRightPlatforms[this.activeRightPlatforms.Count - 1].transform.rotation; //Quaternion.AngleAxis (-90, Vector3.forward);
        CreateRight(true, rightPlatformTag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate);
        

    }


    void GeneratePlatforms()
    {
        int np = difficulty;
        int p = 4 - difficulty;
        if (this.activeBottomPlatforms.Count == 0)
        {
            GameObject x = (GameObject)GameObject.Instantiate(this.PathBottomPlatforms[0], new Vector3(0, -3f, 0), Quaternion.identity);
            x.tag = bottomPlatformTag;
            //			x.gameObject.tag = "BottomPlatform";
            this.activeBottomPlatforms.Add(x);
        }
        if (this.activeLeftPlatforms.Count == 0)
        {
            Quaternion leftRotate = Quaternion.AngleAxis(90, Vector3.forward);
            GameObject x = (GameObject)GameObject.Instantiate(this.PathLeftPlatforms[0], new Vector3(-3f, 0f, 0), leftRotate);
            x.tag = leftPlatformTag;
            //			x.gameObject.tag = "LeftPlatform";
            this.activeLeftPlatforms.Add(x);
        }
        if (this.activeTopPlatforms.Count == 0)
        {
            Quaternion topRotate = Quaternion.AngleAxis(180, Vector3.forward);
            GameObject x = (GameObject)GameObject.Instantiate(this.PathTopPlatforms[0], new Vector3(0, 3f, 0), topRotate);
            //x.gameObject.tag = "TopPlatform";
            x.tag = topPlatformTag;
            this.activeTopPlatforms.Add(x);
        }
        if (this.activeRightPlatforms.Count == 0)
        {
            Quaternion rightRotate = Quaternion.AngleAxis(-90, Vector3.forward);
            GameObject x = (GameObject)GameObject.Instantiate(this.PathRightPlatforms[0], new Vector3(3f, 0, 0), rightRotate);
            //x.gameObject.tag = "RightPlatform";

            x.tag = rightPlatformTag;
            this.activeRightPlatforms.Add(x);
        }

        if (this.activeTopPlatforms.Count != 0 || this.activeRightPlatforms.Count != 0 || this.activeLeftPlatforms.Count != 0 || this.activeBottomPlatforms.Count != 0)
        {
            for (int s = 0; s < 4; s++)
            {
                string nametag = "";
                switch (s)
                {
                    case 0:
                        nametag = bottomPlatformTag;
                        float val = Random.value; //will it be path or no path
                        Vector3 lastBotPlatPos = this.activeBottomPlatforms[this.activeBottomPlatforms.Count - 1].transform.position;
                        Quaternion noRotate = this.activeBottomPlatforms[this.activeBottomPlatforms.Count - 1].transform.rotation; //Quaternion.identity;
                        if (val < .5)
                        {
                            if (np > 0)
                            {
                                np = np - 1;
                                //CreateNoPathPlatform(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
                                CreateBottom(false, nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);

                            }
                            else
                            {
                                //CreatePathPlatform(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
                                p = p - 1;
                                CreateBottom(true, nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
                                //CreatePathPlatform(nametag, GrabPathPlatormBottom(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate));
                                
                                //GameObject bottom = GrabPathPlatormBottom(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
                                //AssignPlatform(bottom, bottomPlatformTag);

                            }
                        }
                        else
                        {
                            if (p > 0)
                            {
                                p = p - 1;
                                CreateBottom(true, nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);

                                //CreatePathPlatform(nametag, GrabPathPlatormBottom(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate));
                                
                                //GameObject bottom = GrabPathPlatormBottom(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
                                //AssignPlatform(bottom, bottomPlatformTag);
                             
                            }
                            else
                            {
                                np = np - 1;
                                CreateBottom(false, nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);

                                //CreateNoPathPlatform(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);

                            }
                        }
                        break;
                    case 1: //Left
                        nametag = leftPlatformTag;

                        float leftval = Random.value; //will it be path or no path
                        Vector3 lastLeftPlatPos = this.activeLeftPlatforms[this.activeLeftPlatforms.Count - 1].transform.position; ;
                        Quaternion leftRotate = this.activeLeftPlatforms[this.activeLeftPlatforms.Count - 1].transform.rotation; ////Quaternion.AngleAxis (90, Vector3.forward);
                        if (leftval < .5)
                        {
                            if (np > 0)
                            {
                                np = np - 1;
                                //CreateNoPathPlatform(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);
                                CreateLeft(false, nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);
    
                            }
                            else
                            {
                                p = p - 1;
                                CreateLeft(true, nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);

                                //CreatePathPlatform(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);
                                //GameObject left = GrabPathPlatormBottom(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);
                                //AssignPlatform(left, bottomPlatformTag);
                            }
                        }
                        else
                        {
                            if (p > 0)
                            {
                                p = p - 1;
                                CreateLeft(true, nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);

                                //CreatePathPlatform(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);

                                //CreatePathPlatform(nametag, GrabPathPlatormBottom(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate));


                                //GameObject left = GrabPathPlatormBottom(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);
                                //AssignPlatform(left, bottomPlatformTag);
                            }
                            else
                            {
                                np = np - 1;

                                CreateLeft(false, nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);

                                //CreateNoPathPlatform(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);

                            }
                        }
                        break;
                    case 2: //Top
                        nametag = topPlatformTag;

                        float topval = Random.value; //will it be path or no path
                        //				Debug.Log ("Top random val: " + topval); 

                        Vector3 lastTopPlatPos = this.activeTopPlatforms[this.activeTopPlatforms.Count - 1].transform.position;
                        Quaternion topRotate = this.activeTopPlatforms[this.activeTopPlatforms.Count - 1].transform.rotation; //Quaternion.AngleAxis (180, Vector3.forward);
                        if (topval < .5)
                        {
                            if (np > 0)
                            {
                                np = np - 1;
                                CreateTop(false, nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);
                                //CreateNoPathPlatform(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);

                            }
                            else
                            {
                                p = p - 1;

                                CreateTop(true, nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);


                                //CreatePathPlatform(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);
                                //CreatePathPlatform(nametag, GrabPathPlatformTop(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate));

                                //GameObject top = GrabPathPlatormBottom(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);
                                //AssignPlatform(top, bottomPlatformTag);

                            }
                        }
                        else
                        {
                            if (p > 0)
                            {
                                p = p - 1;
                                CreateTop(true, nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);


                                //CreatePathPlatform(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);
                                //CreatePathPlatform(nametag, GrabPathPlatformTop(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate));

                                //GameObject top = GrabPathPlatormBottom(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);
                                //AssignPlatform(top, bottomPlatformTag);
                            }
                            else
                            {
                                np = np - 1;

                                CreateTop(false, nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);

                                //CreateNoPathPlatform(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);


                            }
                        }
                        break;
                    case 3: //right
                        nametag = rightPlatformTag;

                        Vector3 lastRightPlatPos = this.activeRightPlatforms[this.activeRightPlatforms.Count - 1].transform.position;
                        Quaternion rightRotate = this.activeRightPlatforms[this.activeRightPlatforms.Count - 1].transform.rotation; //Quaternion.AngleAxis (-90, Vector3.forward);

                        if (np > 0)
                        {
                            np = np - 1;
                            //CreateNoPathPlatform(nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate);
                            CreateRight(false, nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate);

                        }
                        else
                        {
                            p = p - 1;

                            CreateRight(true, nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate);

                        //CreatePathPlatform(nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate);
                        //CreatePathPlatform(nametag, GrabPathPlatformRight(nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate));

                        //GameObject top = GrabPathPlatormBottom(nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate);
                        //AssignPlatform(top, bottomPlatformTag);

                        }


                        break;
                    default:
                        break;
                }
            }
        }

    }

    private void CreateBottom(bool ispath, string tagname, float p2, float botPlatAdjustment, Vector3 lastzVector, Quaternion rq)
    {
        int platformType;

        if (ispath)
        {
            if (beginning)
            {
                platformType = 0;
            }
            else
            {
                platformType = ((int)Random.value) % this.PathBottomPlatforms.Count;

            }
                GameObject x = (GameObject)GameObject.Instantiate(this.PathBottomPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
                x.gameObject.tag = tagname;
                x.transform.parent = this.transform;
                activeBottomPlatforms.Add(x);
            

        }
        else
        {
            platformType = ((int)Random.value) % this.NPBottomPlatforms.Count;
            GameObject z = (GameObject)GameObject.Instantiate(this.NPBottomPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq); //changed xpos and ypos
            z.gameObject.tag = tagname;
            z.transform.parent = this.transform;
            activeBottomPlatforms.Add(z);

        }
  
    }

    private void CreateLeft(bool ispath, string tagname, float p2, float botPlatAdjustment, Vector3 lastzVector, Quaternion rq)
    {
        int platformType;
        if (ispath)
        {
            if (beginning)
            {
                platformType =0;
            }
            else
            {
                platformType = ((int)Random.value) % this.PathLeftPlatforms.Count;
            }
                GameObject x = (GameObject)GameObject.Instantiate(this.PathLeftPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
                x.gameObject.tag = tagname;

                x.transform.parent = this.transform;
                activeLeftPlatforms.Add(x);
            

        }
        else
        {
            platformType = ((int)Random.value) % this.NPLeftPlatforms.Count;
            GameObject z = (GameObject)GameObject.Instantiate(this.NPLeftPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq); //changed xpos and ypos
            z.gameObject.tag = tagname;
            foreach (Transform child in z.transform)
            {
                
                child.tag = tagname;
            }
            z.transform.parent = this.transform;
            activeLeftPlatforms.Add(z);

        }

    }

    private void CreateRight(bool ispath, string tagname, float p2, float botPlatAdjustment, Vector3 lastzVector, Quaternion rq)
    {
        int platformType ;

        if (ispath)
        {
            if (beginning)
            {
                platformType = 0; 
            }
            else
            {
                platformType = ((int)Random.value) % this.PathRightPlatforms.Count;
            }
            GameObject x = (GameObject)GameObject.Instantiate(this.PathRightPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
            x.gameObject.tag = tagname;
            x.transform.parent = this.transform;
            activeRightPlatforms.Add(x);
        }
        else
        {
            platformType = ((int)Random.value) % this.NPRightPlatforms.Count;
            GameObject z = (GameObject)GameObject.Instantiate(this.NPRightPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq); //changed xpos and ypos
            z.gameObject.tag = tagname;
            foreach (Transform child in z.transform)
            {

                child.tag = tagname;
            }
            z.transform.parent = this.transform;
            activeRightPlatforms.Add(z);

        }

    }

    private void CreateTop(bool ispath, string tagname, float p2, float botPlatAdjustment, Vector3 lastzVector, Quaternion rq)
    {
        int platformType ;

        if (ispath)
        {
            if (beginning)
            {
                platformType = 0;
            }else
            {
                platformType = ((int)Random.value) % this.PathTopPlatforms.Count;

            }
            GameObject x = (GameObject)GameObject.Instantiate(this.PathTopPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
            x.gameObject.tag = tagname;
            x.transform.parent = this.transform;
            activeTopPlatforms.Add(x);
        }
        else
        {
            platformType = ((int)Random.value) % this.NPTopPlatforms.Count;
            GameObject z = (GameObject)GameObject.Instantiate(this.NPTopPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq); //changed xpos and ypos
            z.gameObject.tag = tagname;
            z.transform.parent = this.transform;
            activeTopPlatforms.Add(z);

        }

    }


    void CreateNoPathPlatform(string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq)
    {
        int platformType = ((int)Random.value) % this.NoPathPlatforms.Count;
        GameObject z = (GameObject)GameObject.Instantiate(this.NoPathPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq); //changed xpos and ypos
        z.gameObject.tag = tagname;
        z.transform.parent = this.transform;
        //z.transform.rotation = rq; //Possible reset it to fix problem?

        if (tagname.Equals(bottomPlatformTag))
            this.activeBottomPlatforms.Add(z);
        if (tagname.Equals(rightPlatformTag))
            this.activeRightPlatforms.Add(z);
        if (tagname.Equals(topPlatformTag))
            this.activeTopPlatforms.Add(z);
        if (tagname.Equals(leftPlatformTag))
            this.activeLeftPlatforms.Add(z);
    }

    void CreatePathPlatform(string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq)//, GameObject x)
    {
        int platformType = ((int)Random.value) % this.PathPlatforms.Count;
        GameObject x = (GameObject)GameObject.Instantiate(this.PathPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
        x.gameObject.tag = tagname;
        x.transform.parent = this.transform;
        if (tagname.Equals(bottomPlatformTag))
            this.activeBottomPlatforms.Add(x);
        if (tagname.Equals(rightPlatformTag))
            this.activeRightPlatforms.Add(x);
        if (tagname.Equals(topPlatformTag))
            this.activeTopPlatforms.Add(x);
        if (tagname.Equals(leftPlatformTag))
            this.activeLeftPlatforms.Add(x);
    }

    /*
    public GameObject GrabPathPlatformLeft(string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq)
    {
        int platformType = ((int)Random.value) % this.PathLeftPlatforms.Count;
        GameObject x = (GameObject)GameObject.Instantiate(this.PathLeftPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
        return x;
    }
    public GameObject GrabPathPlatformRight(string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq)
    {
        int platformType = ((int)Random.value) % this.PathRightPlatforms.Count;
        GameObject x = (GameObject)GameObject.Instantiate(this.PathRightPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
        return x;
    }

    public GameObject GrabPathPlatformTop(string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq)
    {
        int platformType = ((int)Random.value) % this.PathTopPlatforms.Count;
        GameObject x = (GameObject)GameObject.Instantiate(this.PathTopPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
        return x;
    }

    public GameObject GrabPathPlatormBottom(string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq)
    {
        int platformType = ((int)Random.value) % this.PathBottomPlatforms.Count;
        GameObject x = (GameObject)GameObject.Instantiate(this.PathBottomPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
        return x;
    }

    void AssignPlatform(GameObject x, string tagname){
        x.gameObject.tag = tagname;
        x.transform.parent = this.transform;
        if (tagname.Equals(bottomPlatformTag))
            this.activeBottomPlatforms.Add(x);
        if (tagname.Equals(rightPlatformTag))
            this.activeRightPlatforms.Add(x);
        if (tagname.Equals(topPlatformTag))
            this.activeTopPlatforms.Add(x);
        if (tagname.Equals(leftPlatformTag))
            this.activeLeftPlatforms.Add(x);
    }*/
}
