using SwexFilter.Models;
using SwexFilter.Models.Enums;

namespace SwexFilter.Data
{
    public class DataContext
    {
        private readonly string _FiltersFilePath;
        private readonly string _RunesFilePath;
        public IList<SWEXRune> Runes { get; set; } = [];
        public IList<Filter> Filters { get; set; } = [];

        public DataContext(string FiltersFilePath, string RunesFilePath)
        {
            _FiltersFilePath = FiltersFilePath;
            _RunesFilePath = RunesFilePath;
            LoadData();
            AddSampleRunes();
            AddSampleFilters();
        }

        public void AddRune(SWEXRune rune)
        {
            Runes.Add(rune);
            SaveData();
        }

        public void UpdateRune(SWEXRune rune)
        {
            var existingRune = Runes.FirstOrDefault(r => r.ID == rune.ID);
            if (existingRune is not null)
            {
                existingRune.Set = rune.Set;
                existingRune.Slot = rune.Slot;
                existingRune.Stars = rune.Stars;
                existingRune.Rarity = rune.Rarity;
                existingRune.Level = rune.Level;
                existingRune.MainStat = rune.MainStat;
                existingRune.MainStatValue = rune.MainStatValue;
                existingRune.SubStat1 = rune.SubStat1;
                existingRune.SubStat1Value = rune.SubStat1Value;
                existingRune.SubStat2 = rune.SubStat2;
                existingRune.SubStat2Value = rune.SubStat2Value;
                existingRune.SubStat3 = rune.SubStat3;
                existingRune.SubStat3Value = rune.SubStat3Value;
                existingRune.SubStat4 = rune.SubStat4;
                existingRune.SubStat4Value = rune.SubStat4Value;
                SaveData();
            }
        }

        public void DeleteRune(int id)
        {
            var rune = Runes.FirstOrDefault(r => r.ID == id);
            if (rune is not null)
            {
                Runes.Remove(rune);
                SaveData();
            }
        }

        public void ImportRunes(IEnumerable<SWEXRune> runes)
        {
            Runes.Clear();
            foreach (var rune in runes)
            {
                Runes.Add(rune);
            }
            SaveData();
        }

        public void AddFilter(Filter filter)
        {
            Filters.Add(filter);
            SaveData();
        }

        public void UpdateFilter(Filter filter)
        {
            Filter? existingFilter = Filters.FirstOrDefault(f => f.Name == filter.Name);
            if (existingFilter is not null)
            {
                existingFilter.IsActive = filter.IsActive;
                existingFilter.RelativeScore = filter.RelativeScore;
                existingFilter.SubPropertiesPresence = filter.SubPropertiesPresence;
                existingFilter.SubPropertiesWanted = filter.SubPropertiesWanted;
                existingFilter.ExcludeEnchantedRune = filter.ExcludeEnchantedRune;
                existingFilter.ExcludeGrindFromScore = filter.ExcludeGrindFromScore;
                existingFilter.KeepOnlyIfGemAvailable = filter.KeepOnlyIfGemAvailable;
                existingFilter.KeepOnlyIfGrindAvailable = filter.KeepOnlyIfGrindAvailable;
                SaveData();
            }
        }

        public void DeleteFilter(string name)
        {
            var filter = Filters.FirstOrDefault(f => f.Name == name);
            if (filter is not null)
            {
                Filters.Remove(filter);
                SaveData();
            }
        }

        private void SaveData()
        {
            File.WriteAllText(_FiltersFilePath, System.Text.Json.JsonSerializer.Serialize(Filters));
            File.WriteAllText(_RunesFilePath, System.Text.Json.JsonSerializer.Serialize(Runes));
        }

        private void LoadData()
        {
            if (File.Exists(_FiltersFilePath))
            {
                Filters = System.Text.Json.JsonSerializer.Deserialize(< List < Filter >> (File.ReadAllText(_FiltersFilePath)) ?? [];
            }

            if (File.Exists(_RunesFilePath))
            {
                Runes = System.Text.Json.JsonSerializer.Deserialize(< List < SWEXRune >> (File.ReadAllText(_RunesFilePath)) ?? [];
            }
        }

        private void AddSampleRunes()
        {
            if (Runes.Any()) return;

            Runes.Add(new SWEXRune
            {
                ID = 1,
                Set = RuneSet.Violent,
                Slot = RuneSlot.Slot1,
                Stars = RuneStars.Six,
                Rarity = RuneRarity.Legendary,
                Level = 15,
                MainStat = RuneTypeStat.ATKPercentage,
                MainStatValue = 63,
                SubStat1 = RuneTypeStat.HPPercentage,
                SubStat1Value = 20,
                SubStat2 = RuneTypeStat.CRIRate,
                SubStat2Value = 15,
                SubStat3 = RuneTypeStat.DEFPercentage,
                SubStat3Value = 12,
                SubStat4 = RuneTypeStat.SPD,
                SubStat4Value = 8
            });

            Runes.Add(new SWEXRune
            {
                ID = 2,
                Set = RuneSet.Will,
                Slot = RuneSlot.Slot4,
                Stars = RuneStars.Five,
                Rarity = RuneRarity.Hero,
                Level = 12,
                MainStat = RuneTypeStat.CRIRate,
                MainStatValue = 80,
                SubStat1 = RuneTypeStat.ATKPercentage,
                SubStat1Value = 15,
                SubStat2 = RuneTypeStat.HPPercentage,
                SubStat2Value = 10,
                SubStat3 = RuneTypeStat.DEFPercentage,
                SubStat3Value = 9,
                SubStat4 = RuneTypeStat.Accuracy,
                SubStat4Value = 10
            });

            Runes.Add(new SWEXRune
            {
                ID = 3,
                Set = RuneSet.Swift,
                Slot = RuneSlot.Slot2,
                Stars = RuneStars.Six,
                Rarity = RuneRarity.Legendary,
                Level = 15,
                MainStat = RuneTypeStat.SPD,
                MainStatValue = 42,
                SubStat1 = RuneTypeStat.ATKPercentage,
                SubStat1Value = 15,
                SubStat2 = RuneTypeStat.CRIRate,
                SubStat2Value = 12,
                SubStat3 = RuneTypeStat.HPPercentage,
                SubStat3Value = 8,
                SubStat4 = RuneTypeStat.DEFFlat,
                SubStat4Value = 10
            });

            SaveData();
        }

        private void AddSampleFilters()
        {
            if (Filters.Any()) return;

            Filters.Add(new Filter
            {
                Name = "Legendary Violent Runes",
                IsActive = true
            });

            Filters.Add(new Filter
            {
                Name = "High SPD Runes",
                IsActive = false
            });

            Filters.Add(new Filter
            {
                Name = "Swift Runes with CRI Rate",
                IsActive = true
            });

            SaveData();
        }

    }
}
