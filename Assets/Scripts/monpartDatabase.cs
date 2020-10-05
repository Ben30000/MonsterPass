using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monpartDatabase : MonoBehaviour
{
    public int numberEyes = 2;
    public int numberEars = 2;
    public int numberHorns = 4;
    public int numberTails = 2;
    public Sprite eye1;
    public Sprite eye2;
    public Sprite ear1;
    public Sprite ear2;
    public Sprite horn1;
    public Sprite horn2;
    public Sprite horn3;
    public Sprite horn4;
    public Sprite tail1;
    public Sprite tail2;

    public Sprite getEye(int num){
        switch(num){
            case(1): return eye1;
            case(2): return eye2;
            default: return eye1;
        }
    }

    public Sprite getEar(int num){
        switch(num){
            case(1): return ear1;
            case(2): return ear2;
            default: return ear1;
        }
    }

    public Sprite getHorn(int num){
            switch(num){
                case(1): return horn1;
                case(2): return horn2;
                case(3): return horn3;
                case(4): return horn4;
                default: return horn1;
            }
        }


    public Sprite getTail(int num){
        switch(num){
            case(1): return tail1;
            case(2): return tail2;
            default: return tail1;
        }
    }

    
}
