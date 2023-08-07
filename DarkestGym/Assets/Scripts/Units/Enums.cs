using UnityEngine;

enum AbilityName
{
    //Гигажаб
    [Tooltip("Презрение к слабым")] ContempForTheWeak,
    [Tooltip("Крушить уже не модно")]  ItIsNoLongerFashionableToDestroy,
    [Tooltip("Снисхождение к слабым")] ContemotForTheWeak,
    //FeiChao
    [Tooltip("Улучшененный ход")] ImprovingActing,
    //Linnet
    [Tooltip("Нет штрафа в ближнем бою")] NoMeleePenalty,
    [Tooltip("Смена позиций")] ChangingPositions,
    //Tank
    [Tooltip("Отражение урона в ближнем бою")] ReflectionOfMeleeDamage,
    //Range
    [Tooltip("Слабость в ближнем бою")] WeaknessInCloseCombat
}