﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuetzalcotlHand : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("Player")) {
			coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(FindObjectOfType<QuetzalcotlAI>().attackDamage);
		}
	}
}
