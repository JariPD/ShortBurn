using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classes use Pascalcase
public class CodingConvention : MonoBehaviour
{
    // Enums with more then 3 states are made like below
    public enum MyEnum1
    {
        idle,
        wander,
        pursue,
        attack,
        dead
    }

    // Enums with less or equal to 3 states are made like below

    public enum MyEnum2 { idle, wander, pursue }


    //----------------------------------------------------------------------------------------------------------------\\


    // Public variables use Pascalcase
    public float Speed = 10f;

    // Private variables use Camelcase
    private bool isGrounded = false;

    // Protected variables use Camelcase
    protected bool ableToJump = false;

    // Properties use Camelcase
    private string myProperty { get; set; }

    // Consts use Camelcase
    const int valueThatDoesntChange = 10;


    // Functions use Pascalcase
    public void CodingConventions()
    {

        //----------------------------------------------------------------------------------------------------------------\\


        // Bracket style = non egyptian

        if (isGrounded)
        {
            ableToJump = true;
        }

        // If the if statement is one line the brackets are removed

        if (isGrounded)
            ableToJump = true;



        //----------------------------------------------------------------------------------------------------------------\\

        // Local variables
        // I keep local variables short. local variables use Camelcase

        //float x = 10;
        //float y = 10;

        //float mouseX = 20;


        //----------------------------------------------------------------------------------------------------------------\\
    }

    // Structs use Pascalcase
    public struct Item
    {

    }
}
