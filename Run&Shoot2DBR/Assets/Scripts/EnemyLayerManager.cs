using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyLayerManager : MonoBehaviour
{
    public static EnemyLayerManager instance;

    List<SpriteRenderer> enemiesSpriteRenderer = new List<SpriteRenderer>();
    public void Add(SpriteRenderer addSprite) { enemiesSpriteRenderer.Add(addSprite); }
    public void Delete(SpriteRenderer deleteSprite) { enemiesSpriteRenderer.Remove(deleteSprite); }

    float[] positionYs;
    SpriteRenderer[] spriteFewRenderers;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(nameof(Check));
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(1);
        int n = enemiesSpriteRenderer.Count;

        positionYs = new float[n];
        spriteFewRenderers = new SpriteRenderer[n];
        for (int i = 0; i < n; i++)
        {
            positionYs[i] = enemiesSpriteRenderer[i].transform.position.y;
            spriteFewRenderers[i] = enemiesSpriteRenderer[i];

        }
        Array.Sort(positionYs, spriteFewRenderers);
        for (int i = 0; i < spriteFewRenderers.Length; i++)
        {
            spriteFewRenderers[i].sortingOrder = -i;
        }
        StartCoroutine(nameof(Check));
    }
}
