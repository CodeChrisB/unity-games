using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    new Transform transform;
    [SerializeField]
    private GameObject Pill;
    [SerializeField]
    private GameObject CodeLessCoffee;
    [SerializeField]
    private GameObject Lamp;
    [SerializeField]
    private GameObject CatImage;
    [SerializeField]
    private GameObject Banana;
    [SerializeField]
    private GameObject Cat;
    [SerializeField]
    private GameObject Door;
    [SerializeField]
    private TMP_Text BigText;
    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private AudioClip survey_successfull;

    public void Start()
    {
       
    }

    #region GetScripts
    public LookAround GetCameraScript()
    {
        GameObject obj = GameObject.Find("Player");
        return  (LookAround)obj.GetComponent(typeof(LookAround));
    }

    public LampSwitch GetLampScript()
    {
       return (LampSwitch)GameObject.Find("DeskLamp").GetComponent(typeof(LampSwitch));
    }
    public PlayerMovement GetMovementScript()
    {
        return (PlayerMovement)GameObject.Find("FPP").GetComponent(typeof(PlayerMovement));
    }
    #endregion
    #region Pill
    public void SpawnPill()
    {
       
        Vector3 position = new Vector3(7.71f, 11.78f, 10.04f);
        Pill.transform.position = position;
        Instantiate(Pill,transform);

    }
    #endregion
    #region Coffee
    public void FillCoffee()
    {
        GameObject obj = GameObject.Find("CoffeeMug");
        Coffee coffee = (Coffee)obj.GetComponent(typeof(Coffee));
        coffee.FillCoffee();
    }

    public void SpawnCoffe(Vector3 pos)
    {
        CodeLessCoffee.transform.position = pos;
        Instantiate(CodeLessCoffee, transform);
    }
    public void SpawnCoffe(Vector3 pos, float size)
    {
        CodeLessCoffee.transform.position = pos;

        CodeLessCoffee.transform.localScale = new Vector3(size, size, size);
        Instantiate(CodeLessCoffee, transform);
        CodeLessCoffee.transform.localScale = new Vector3(1, 1, 1);
    }
    public void DestroyCoffe()
    {
        GameObject obj = GameObject.Find("CoffeeMug");
        Coffee coffee = (Coffee)obj.GetComponent(typeof(Coffee));
        coffee.DestroyCoffe();
    }
    public void ResetAfterNextCoffee()
    {
        GameObject obj = GameObject.Find("CoffeeMug");
        Coffee coffee = (Coffee)obj.GetComponent(typeof(Coffee));
        coffee.ResetOnNextClick();
    }
    #endregion
    #region Cat
    public void ForceCat()
    {
        //remove the camera movement

        LookAround cameraMovement = GetCameraScript();
        cameraMovement.transform.eulerAngles = new Vector3(10, -80f, 0f);
        cameraMovement.canMove = false;

        //set the roation
  
        Thread.Sleep(5000);
        cameraMovement.canMove = true;

    }
    #endregion
    #region Camera
    public void CanMove() => GetCameraScript().canMove = true;
    public void CanWalk() => GetMovementScript().CanWalk = true;
    #endregion

    #region Door
    public void OpenMainDoor() => Destroy(Door);
    #endregion

    public void Audio(int type)
    {

    }

    public void SpawnCatImage()
    {
        CatImage.SetActive(true);
    }

    internal void SpawnBanana()
    {
        Banana.SetActive(true);
    }

    internal void stopWatch(int v)
    {

        /*
        SetBigText(timer.ToString());
        if (timer > 0)
        {
            Thread.Sleep(1000);
            Timer();
        }
        else
        {
            FreeFromCat();
        }*/
    }

    public void RemoveLamp() => GetLampScript().Remove();

    internal void SpawnCat()
    {
        Transform cat = Cat.transform;
        cat.position = new Vector3(7.92f, 11.75f, 9.41f);
        cat.eulerAngles = new Vector3(0f, 40f, 0f);
        cat.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Instantiate(Cat,cat);
    }

    internal void SpawnLotsOfCat()
    {
        throw new NotImplementedException();
    }

    internal void SpawnLotsOfImages()
    {
        throw new NotImplementedException();
    }

    internal void LampGame() => GetLampScript().lampGame();
}
