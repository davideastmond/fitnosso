using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
namespace fitnosso
{
    public class Exercise
    {
        // An exercise is a user-defined objects outlining an exercise that as performed
        public string ExerciseType;
        public string Description;
        public static Exercise DefaultExercise
        {
            get
            {
                Exercise t_ex = new  Exercise("default", "default");
                return t_ex;
            }

        }
        public Exercise(string p_eType, string p_eDesc)
        {
            this.ExerciseType = p_eType;
            this.Description = p_eDesc;
        }
    }
}
