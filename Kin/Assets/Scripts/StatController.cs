using UnityEngine;
using System.Collections;

public class StatController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	//Set methods
	public void setHealth(int playerHealth)
	{
		healthLvlP = playerHealth;
	}

	public void setHealthOrder(int playerHealthOrder)
	{
		healthLvlO = playerHealthOrder;
	}

	public void setStamina(int playerStamina)
	{
		stamLvlP = playerStamina;
	}

	public void setStaminaOrder(int playerStaminaOrder)
	{
		stamLvlO = playerStaminaOrder;
	}

	public void setStrength(int playerStrength)
	{
		strLvlP = playerStrength;
	}

	public void setStrengthOrder(int playerStrengthOrder)
	{
		strLvlO = playerStrengthOrder;
	}

	public void setWisdom(int playerWisdom)
	{
		wisLvlP = playerWisdom;
	}

	public void setWisdomOrder(int playerWisdomOrder)
	{
		wisLvlO = playerWisdomOrder;
	}

    //Get methods
    public int getHealth()
    {
        return healthLvlP;
    }

    public int getHealthOrder()
    {
        return healthLvlO;
    }

    public int getStamina()
    {
        return stamLvlP;
    }

    public int getStaminaOrder()
    {
        return stamLvlO;
    }

    public int getStrength()
    {
        return strLvlP;
    }

    public int getStrengthOrder()
    {
        return strLvlO;
    }

    public int getWisdom()
    {
        return wisLvlP;
    }

    public int getWisdomOrder()
    {
        return wisLvlO;
    }
}

