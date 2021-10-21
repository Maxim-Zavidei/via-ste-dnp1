using System;

namespace GameQuestLogic {
    class Program {

        static bool CanFastAttack(bool isKnightAwake) {
            return isKnightAwake;
        }
        
        static bool CanSpy(bool isKnightAwake, bool isArcherAwake) {
            return isKnightAwake || isArcherAwake;
        }

        static bool CanSignal(bool isPrisonerAwake, bool isArcherAwake) {
            return isPrisonerAwake && !isArcherAwake;
        }

        static bool CanFree(bool hasDog, bool isPrisonerAwake, bool isKnightAwake, bool isArcherAwake) {
            return (isPrisonerAwake && !isArcherAwake && !isKnightAwake) || (hasDog && !isArcherAwake);
        }

        static void Main(string[] args) {
            Console.WriteLine(CanFree(true, true, false, false));
        }
    }
}