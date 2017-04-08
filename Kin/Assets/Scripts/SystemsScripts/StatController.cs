using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StatController : MonoBehaviour
{

	private int healthLvlP;
	private int healthLvlO;
	private int health;
	private int stamLvlP;
	private int stamLvlO;
	private int stamina;
	private int strLvlP;
	private int strLvlO;
	private int strength;
	private int wisLvlP;
	private int wisLvlO;
	private int wisdom;

	// Use this for initialization
	void Awake ()
	{
		healthLvlO = 1;
		healthLvlP = 10;
		health = 400;
		stamLvlO = 1;
		stamLvlP = 8;
		stamina = 1500;
		strLvlO = 1;
		strLvlP = 10;
		strength = 10;
		wisLvlO = 1;
		wisLvlP = 5;
		wisdom = 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	void levelUpHealth(bool OrderFalsePlayerTrue)
    {
        int levelOrder = getHealthOrder();
        int currentLevel = getHealthLvl();
        //GIVE DESIRED LEVEL

        bool agreeToLevel = true;
        float daysRequired = levelUpFunction(levelOrder, currentLevel, currentLevel + 1);
		if (agreeToLevel && daysRequired != -1)
        {
            //Subtract Days

            //Level Up Stat By Pursued
			if (OrderFalsePlayerTrue) {
				healthLvlP = currentLevel + 1;
			}else{
				levelOrder += 1;
				switch (levelOrder) {
				case 1:
					healthLvlO = 1;
					health = 300 + 10 * healthLvlP;
				case 2:
					healthLvlO = 2;
					health = health + 10 * healthLvlP;
				case 3:
					healthLvlO = 3;
					health = health + 20 * healthLvlP;
				case 4:
					healthLvlO = 4;
					health = health + 35 * healthLvlP;
				case 5:
					healthLvlO = 5;
					health = health + 55 * healthLvlP;
				}
			}
        }
    }

    //level up
	void levelUpStamina(bool OrderFalsePlayerTrue)
    {
        int levelOrder = getStaminaOrder();
        int currentLevel = getStaminaLvl();
        //GIVE DESIRED LEVEL

        bool agreeToLevel = true;
        float daysRequired = levelUpFunction(levelOrder, currentLevel, currentLevel + 1);
		if (agreeToLevel && daysRequired != -1)
        {
            //Subtract Days
            //TimeController.ProgressDay((int)daysRequired);
            //Level Up Stat By Pursued
			if (OrderFalsePlayerTrue) {
				setStaminaLvl (currentLevel + 1);
			}else{
				levelOrder += 1;
				switch (levelOrder) {
				case 1:
					stamLvlO = 1;
					stamina = 1500 + 50 * stamLvlP;
				case 2:
					healthLvlO = 2;
					health = health + 15 * stamLvlP;
				case 3:
					healthLvlO = 3;
					health = health + 20 * stamLvlP;
				case 4:
					healthLvlO = 4;
					health = health + 35 * healthLvlP;
				case 5:
					healthLvlO = 5;
					health = health + 55 * healthLvlP;
				}
			}
        }
    }

    //level up
	void levelUpStrength(bool OrderFalsePlayerTrue)
    {
        int levelOrder = getStrengthOrder();
        int currentLevel = getStrength();
        //GIVE DESIRED LEVEL

        bool agreeToLevel = true;
        float daysRequired = levelUpFunction(levelOrder, currentLevel, currentLevel + 1);
		if (agreeToLevel && daysRequired != -1)
        {
            //Subtract Days
            //TimeController.ProgressDay((int)daysRequired);
            //Level Up Stat By Pursued
			if (OrderFalsePlayerTrue) {
				setStrengthLvl (currentLevel + 1);
			}else{
				setStrengthOrder (levelOrder + 1);
			}
        }
    }

    //level up
	void levelUpWisdom(bool OrderFalsePlayerTrue)
    {
        int levelOrder = getWisdomOrder();
        int currentLevel = getWisdom();
        //GIVE DESIRED LEVEL

        bool agreeToLevel = true;
        float daysRequired = levelUpFunction(levelOrder, currentLevel, currentLevel + 1);
		if (agreeToLevel && daysRequired != -1)
        {
            //Subtract Days
            //TimeController.ProgressDay((int)daysRequired);
            //Level Up Stat By Pursued
			if (OrderFalsePlayerTrue) {
				setWisdomLvl (currentLevel + 1);
			}else{
				setWisdomOrder (levelOrder + 1);
			}
        }
    }

    IEnumerable<int> availableLevels(int levelOrder, int currentLevel)
    {
        int maxLevel = 0;
        switch (levelOrder)
        {
            case 0:
                maxLevel = 0;
                //Cannot level up
                break;
            case 1:
                maxLevel = 35;
                break;
            case 2:
                maxLevel = 55;
                break;
            case 3:
                maxLevel = 75;
                break;
            case 4:
                maxLevel = 90;
                break;
            case 5:
                maxLevel = 100;
                break;
        }
        IEnumerable<int> range = Enumerable.Range(currentLevel + 1, maxLevel);
        return range;
    }


    float levelUpFunction(int levelOrder, int currentLevel, float levelPursued)
    {
        //get levelPursused from available levels
        //float nFunc = 0f;
        //if (levelOrder > 1 || levelOrder <= 3)
        //{
        //    nFunc = 0.5f + 0.5f * levelOrder;
        //}
        //if (levelOrder > 3)
        //{
        //    nFunc = levelOrder - 1;
        //}
        //float daysRequired = (450 - 50 * nFunc) * (1 - Mathf.Pow(2, -levelPursued / 20f)) + Mathf.Pow(1.5f, levelPursued / (2f * nFunc));
        //This is in case you can't reach that level
        float daysRequired = Mathf.Infinity;
        IEnumerable<int> levelRange = availableLevels(levelOrder, currentLevel);
        int maxLevel = levelRange.Max();
        if (levelRange.Contains<int>((int)levelPursued))
        {
            daysRequired = 53620 * (Mathf.Exp(0.05f * (levelPursued-maxLevel)) - Mathf.Exp(0.05f * (currentLevel-maxLevel)));
        }
		if (daysRequired > 1872000) {
			daysRequired = -1;
		}
        return daysRequired;
    }

    //Set methods
    public void setHealthLvl(int playerLevel)
	{
		healthLvlP = playerLevel;
	}
		
	public void setHealthOrder(int playerHealthOrder)
	{
		healthLvlO = playerHealthOrder;
	}

	public void setHealth(int playerHealth){
		health = playerHealth;
	}

	public void setStaminaLvl(int staminaLevel)
	{
		stamLvlP = staminaLevel;
	}

	public void setStaminaOrder(int playerStaminaOrder)
	{
		stamLvlO = playerStaminaOrder;
	}

	public void setStamina(int playerStamina)
	{
		stamina = playerStamina;
	}

	public void setStrengthLvl(int strengthLvl)
	{
		strLvlP = strengthLvl;
	}

	public void setStrengthOrder(int playerStrengthOrder)
	{
		strLvlO = playerStrengthOrder;
	}

	public void setStrength(int playerStrength)
	{
		strength = playerStrength;
	}

	public void setWisdomLvl(int wisdomLevel)
	{
		wisLvlP = wisdomLevel;
	}

	public void setWisdomOrder(int playerWisdomOrder)
	{
		wisLvlO = playerWisdomOrder;
	}

	public void setWisdom(int playerWisdom)
	{
		wisdom = playerWisdom;
	}

    //Get methods
    public int getHealth()
    {
        return health;
    }

    public int getHealthOrder()
    {
        return healthLvlO;
    }

	public int getHealthLvl()
	{
		return healthLvlP;
	}

    public int getStamina()
    {
        return stamina;
    }

    public int getStaminaOrder()
    {
        return stamLvlO;
    }

	public int getStaminaLvl()
	{
		return stamLvlP;
	}

    public int getStrength()
    {
		return strength;
    }

    public int getStrengthOrder()
    {
        return strLvlO;
    }

	public int getStrengthLvl()
	{
		return strLvlP;
	}

    public int getWisdom()
    {
        return wisdom;
    }

    public int getWisdomOrder()
    {
        return wisLvlO;
    }

	public int getWisdomLvl()
	{
		return wisLvlP;
	}
}

