using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class SonicInflationScript : MonoBehaviour {

   //public variables
   public KMBombInfo bomb;
   public KMAudio audio;

   //Add buttons to selectable list
    
   public KMSelectable buttonCentre;   

   public Renderer Picture;

   public GameObject centreimagepicture;

   public TextMesh counttext;

   public Material[] images;

   private Vector3 scaleChange;
   int inflationvalue;  

 //asas

   static int ModuleIdCounter = 1;
   int ModuleId;
   private bool ModuleSolved;


   //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   void Awake () {
      ModuleId = ModuleIdCounter++;

      // Make functions called PressButtonX occur when you press buttonX 
      buttonCentre.OnInteract += delegate () { PressButtonCentre(); return false; };   


      //scaleChange vector3
      scaleChange = new Vector3(-0.05f, 0.0f, -0.05f);

   

   }
   //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   void Start () {

   StartCoroutine(mycountdownCoroutine());

      
   }
   //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   void Update () {
      //Currently does nothing
   }
   //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   void PressButtonCentre()
   {  //Pressed center button

      if (ModuleSolved == false){
         //Increase inflationvalue
         inflationvalue = inflationvalue + 1;
         //increase sonic's size
         centreimagepicture.transform.localScale -= scaleChange;
         //update text for beta-testing
         counttext.text = "" + inflationvalue;

         //check for solve
         Solvecheck();
      }
   }
   //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------   
   void Imageupdate()
   {  //update sonic image
      
   }
   //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
   void Solvecheck()
   {  //check for solved
      if(inflationvalue >=30){
         ModuleSolved = true;
         Picture.sharedMaterial = images[0];
         GetComponent<KMBombModule>().HandlePass();
      }

   }
   //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
   private IEnumerator mycountdownCoroutine()
   {
      //While bomb is not solved
      while(ModuleSolved == false){
        
        //if inflation is greater than zero
        if (inflationvalue > 0) {
         
         //decrease it and sonic's size
         inflationvalue = inflationvalue - 1;
         centreimagepicture.transform.localScale += scaleChange;
        }
         //update the text
        counttext.text = "" + inflationvalue;
         yield return new WaitForSeconds(0.5f);     
      }
      
   }
   
}



