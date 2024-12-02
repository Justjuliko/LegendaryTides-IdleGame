using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIEventManager : MonoBehaviour
{
    [Header("---BUY SPAWN SETTINGS---")]
    [SerializeField] Vector2 spawnAreaMin;
    [SerializeField] Vector2 spawnAreaMax;
    [SerializeField] GameObject spawnParent;

    [Header("---EVENT SETTINGS---")]
    [SerializeField] GameObject doubleGoldUIObject;
    [SerializeField] GameObject halfGoldUIObject;
    [SerializeField] GameObject combatUIObject;
    [SerializeField] GameObject combatLossUIObject;
    [SerializeField] GameObject combatWinUIObject;

    [Header("---HEALTH BARS---")]
    [SerializeField] Slider playerHealthBar;
    [SerializeField] Slider enemyHealthBar;

    bool toggleStatusDouble = false;
    bool toggleStatusHalf = false;
    bool toggleStatusCombat = false;
    bool toggleStatusLoseCombat = false;
    bool toggleStatusWinCombat = false;

    public void SpawnShip(Ship ship)
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y) );

        GameObject spawnedShip = Instantiate(ship.shipPrefab, randomPosition, Quaternion.identity);
        spawnedShip.transform.SetParent(spawnParent.transform);
        spawnedShip.transform.localPosition = randomPosition;
    }
    public void DoubleGoldUI()
    {
            toggleStatusDouble = !toggleStatusDouble;
            doubleGoldUIObject.SetActive(toggleStatusDouble);
    }
    public void HalfGoldUI()
    {
        toggleStatusHalf = !toggleStatusHalf;
        halfGoldUIObject.SetActive(toggleStatusHalf);
    }
    public void CombatUI()
    {
        toggleStatusCombat = !toggleStatusCombat;
        combatUIObject.SetActive(toggleStatusCombat);
    }
    public void onPlayerLose()
    {
        StartCoroutine(playerLose());
    }

    private IEnumerator playerLose()
    {
        toggleStatusLoseCombat = !toggleStatusLoseCombat;
        combatLossUIObject.SetActive(toggleStatusLoseCombat);
        
        yield return new WaitForSeconds(5f);

        toggleStatusLoseCombat = !toggleStatusLoseCombat;
        combatLossUIObject.SetActive(toggleStatusLoseCombat);

        StopCoroutine(playerLose());
    }

    public void onPlayerWin()
    {
        StartCoroutine(playerWin());
    }

    private IEnumerator playerWin()
    {
        toggleStatusWinCombat = !toggleStatusWinCombat;
        combatWinUIObject.SetActive(toggleStatusWinCombat);

        yield return new WaitForSeconds(5f);

        toggleStatusWinCombat = !toggleStatusWinCombat;
        combatWinUIObject.SetActive(toggleStatusWinCombat);

        StopCoroutine(playerWin());
    }
    public void UpdateHealthBars(float playerHealth, float maxPlayerHealth, float enemyHealth, float maxEnemyHealth)
    {
        playerHealthBar.value = playerHealth / maxPlayerHealth;
        enemyHealthBar.value = enemyHealth / maxEnemyHealth;    
    }
}
