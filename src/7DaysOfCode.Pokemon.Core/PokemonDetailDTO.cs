namespace _7DaysOfCode.Pokemon.Core
{
    public class PokemonDetailDTO
    {
        public IList<PokemonAbility> Abilities { get; set; } = new List<PokemonAbility>();

        public int Height { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; } = string.Empty;

        public class PokemonAbility
        {
            public PokemonAbilityDetail? Ability { get; set; }

            public class PokemonAbilityDetail
            {
                public string Name { get; set; } = string.Empty;
            }
        }
    }
}
