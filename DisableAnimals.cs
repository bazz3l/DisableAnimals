namespace Oxide.Plugins
{
    [Info("Disable Animals", "Bazz3l", "1.0.0")]
    [Description("Disables animal movements and actions.")]
    class DisableAnimals : RustPlugin
    {
        void OnEntitySpawned(BaseAnimalNPC animal) => DisableAnimalNPC(animal);

        void DisableAnimalNPC(BaseAnimalNPC animal)
        {
            if (animal == null || !animal.isServer)
            {
                return;
            }

            animal.CancelInvoke(animal.TickAi);
            animal.CurrentBehaviour = BaseNpc.Behaviour.Idle;
            animal.IsDormant = true;

            AnimalSensesLoadBalancer.animalSensesLoadBalancer.Remove(animal);
        }
    }
}