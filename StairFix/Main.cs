using MelonLoader;
using System;
using UnityEngine;

namespace StairFix
{
    public static class BuildInfo
    {
        public const string ModName = "StairsFix";
        public const string ModVersion = "2.0.1";
        public const string Description = "Obstructs the jail.";
        public const string Author = "Baumritter";
        public const string Company = "";
    }
    public class StairFixClass : MelonMod
    {
        //constants
        private const double SceneDelay = 4.0;

        //variables
        private readonly bool debuglog = false;
        private bool loaddelaydone = false;
        private bool loadlockout = false;
        private bool DoOnce = false;

        private DateTime loaddelay;

        private string currentscene;

        //objects
        GameObject Frame;
        GameObject Box1;
        GameObject Box2;

        //initializes things
        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
        }
        public override void OnLateInitializeMelon()
        {
            base.OnLateInitializeMelon();
        }

        //Run every update
        public override void OnUpdate()
        {
            //Base Updates
            base.OnUpdate();
            LoadDelayLogic();
            if (currentscene == "Gym" && loaddelaydone && !DoOnce)
            {

                #region Frame
                Frame = new GameObject { name = "StairsFix" };
                Frame.transform.localPosition = new Vector3(11.5f, 0.4f, -3.25f);
                Frame.transform.localEulerAngles = new Vector3(0, 50, 0);
                #endregion

                Box1 = GameObject.Find("--------------LOGIC--------------/Heinhouser products/Howard root/Props/Crate (5)");
                Box2 = GameObject.Instantiate(Box1);
                for (int i = 0;i < Box2.transform.childCount;i++)
                {
                    Box2.transform.GetChild(i).gameObject.SetActive(false);
                }

                for (int i = 0;i <= 6; i++)
                {
                    Box1 = GameObject.Instantiate(Box2);
                    Box1.transform.SetParent(Frame.transform);
                    Box1.name = "StairsCrate";
                    switch (i)
                    {
                        case 0:
                            Box1.transform.localPosition = new Vector3(-0.2f,0f,0.075f);
                            Box1.transform.localEulerAngles = new Vector3(0f, 0f, 5.5f);
                            break;
                        case 1:
                            Box1.transform.localPosition = new Vector3(0.44f, -0.03f, 0.075f);
                            Box1.transform.localEulerAngles = new Vector3(0.6f, 0f, 336.4f);
                            break;
                        case 2:
                            Box1.transform.localPosition = new Vector3(0.77f, -0.755f, 0.075f);
                            Box1.transform.localEulerAngles = new Vector3(0f, 355f, 0.7f);
                            break;
                        case 3:
                            Box1.transform.localPosition = new Vector3(0.79f, -1.335f, 0.035f);
                            Box1.transform.localEulerAngles = new Vector3(359f, 10f, 1.7f);
                            break;
                        case 4:
                            Box1.transform.localPosition = new Vector3(-0.04f, -0.849f, -0.54f);
                            Box1.transform.localEulerAngles = new Vector3(0f, 2.562f, 339.14f);
                            break;
                        case 5:
                            Box1.transform.localPosition = new Vector3(0.281f, -0.474f, -0.53f);
                            Box1.transform.localEulerAngles = new Vector3(0f, 3.662f, 20.2758f);
                            Box1.transform.localScale = new Vector3(0.52f, 0.52f, 0.52f);
                            break;
                        case 6:
                            Box1.transform.localPosition = new Vector3(0.09f, -0.19f, 0.975f);
                            Box1.transform.localEulerAngles = new Vector3(0f, 352.3685f, 329.4683f);
                            Box1.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                            break;
                    }
                }

                GameObject.Destroy(Box2);

                DoOnce = true;
            }
        }

        //Basic Functions
        public void LoadDelayLogic()
        {
            if (!loaddelaydone && !loadlockout)
            {
                loaddelay = DateTime.Now.AddSeconds(SceneDelay);
                loadlockout = true;
                if (debuglog) MelonLogger.Msg("LoadDelay: Start.");
                if (debuglog) MelonLogger.Msg(loaddelay.ToString());
            }
            if (DateTime.Now >= loaddelay && !loaddelaydone)
            {
                loaddelaydone = true;
                if (debuglog) MelonLogger.Msg("LoadDelay: End.");
            }
        }

        //Overrides
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            currentscene = sceneName;
            loaddelaydone = false;
            loadlockout = false;
            DoOnce = false;
        }
    }
}

