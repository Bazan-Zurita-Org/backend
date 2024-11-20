﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UFit.Infrastructure;

#nullable disable

namespace UFit.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UFit.Domain.Challenges.Challenge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Rewards")
                        .HasColumnType("integer")
                        .HasColumnName("rewards");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_challenges");

                    b.ToTable("challenges", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Challenges.TraineeChallenge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ChallengeId")
                        .HasColumnType("uuid")
                        .HasColumnName("challenge_id");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("completion_date");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid>("TraineeId")
                        .HasColumnType("uuid")
                        .HasColumnName("trainee_id");

                    b.HasKey("Id")
                        .HasName("pk_trainee_challenges");

                    b.HasIndex("ChallengeId")
                        .HasDatabaseName("ix_trainee_challenges_challenge_id");

                    b.HasIndex("TraineeId")
                        .HasDatabaseName("ix_trainee_challenges_trainee_id");

                    b.ToTable("trainee_challenges", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Diets.Diet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Duration")
                        .HasColumnType("integer")
                        .HasColumnName("duration");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("goal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_diets");

                    b.ToTable("diets", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Diets.DietTrainee", b =>
                {
                    b.Property<Guid>("DietId")
                        .HasColumnType("uuid")
                        .HasColumnName("diet_id");

                    b.Property<Guid>("TraineeId")
                        .HasColumnType("uuid")
                        .HasColumnName("trainee_id");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_completed");

                    b.HasKey("DietId", "TraineeId")
                        .HasName("pk_diet_trainees");

                    b.HasIndex("TraineeId")
                        .HasDatabaseName("ix_diet_trainees_trainee_id");

                    b.ToTable("diet_trainees", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Diets.FoodItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("MealId")
                        .HasColumnType("uuid")
                        .HasColumnName("meal_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_food_items");

                    b.HasIndex("MealId")
                        .HasDatabaseName("ix_food_items_meal_id");

                    b.ToTable("food_items", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Diets.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("DietId")
                        .HasColumnType("uuid")
                        .HasColumnName("diet_id");

                    b.Property<TimeSpan>("ScheduleTime")
                        .HasColumnType("interval")
                        .HasColumnName("schedule_time");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_meals");

                    b.HasIndex("DietId")
                        .HasDatabaseName("ix_meals_diet_id");

                    b.ToTable("meals", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Duels.Duel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ChallengeId")
                        .HasColumnType("uuid")
                        .HasColumnName("challenge_id");

                    b.Property<string>("ChallengeText")
                        .HasColumnType("text")
                        .HasColumnName("challenge_text");

                    b.Property<Guid>("ChallengerId")
                        .HasColumnType("uuid")
                        .HasColumnName("challenger_id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<Guid>("OpponentId")
                        .HasColumnType("uuid")
                        .HasColumnName("opponent_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_duels");

                    b.HasIndex("ChallengeId")
                        .HasDatabaseName("ix_duels_challenge_id");

                    b.HasIndex("ChallengerId")
                        .HasDatabaseName("ix_duels_challenger_id");

                    b.HasIndex("OpponentId")
                        .HasDatabaseName("ix_duels_opponent_id");

                    b.ToTable("duels", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Trainees.Trainee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FitnessGoal")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fitness_goal");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("identity_id");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<decimal>("TargetWeight")
                        .HasColumnType("numeric")
                        .HasColumnName("target_weight");

                    b.HasKey("Id")
                        .HasName("pk_trainees");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_trainees_email");

                    b.HasIndex("IdentityId")
                        .IsUnique()
                        .HasDatabaseName("ix_trainees_identity_id");

                    b.ToTable("trainees", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Workouts.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("equipment");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("instructions");

                    b.Property<string>("MuscleGroup")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("muscle_group");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Reps")
                        .HasColumnType("integer")
                        .HasColumnName("reps");

                    b.Property<TimeSpan>("RestTime")
                        .HasColumnType("interval")
                        .HasColumnName("rest_time");

                    b.Property<int>("Sets")
                        .HasColumnType("integer")
                        .HasColumnName("sets");

                    b.HasKey("Id")
                        .HasName("pk_exercises");

                    b.ToTable("exercises", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Workouts.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("integer")
                        .HasColumnName("difficulty_level");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("goal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_workouts");

                    b.ToTable("workouts", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Workouts.WorkoutExercise", b =>
                {
                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uuid")
                        .HasColumnName("workout_id");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uuid")
                        .HasColumnName("exercise_id");

                    b.Property<int>("Reps")
                        .HasColumnType("integer")
                        .HasColumnName("reps");

                    b.Property<int>("Sets")
                        .HasColumnType("integer")
                        .HasColumnName("sets");

                    b.HasKey("WorkoutId", "ExerciseId")
                        .HasName("pk_workout_exercises");

                    b.HasIndex("ExerciseId")
                        .HasDatabaseName("ix_workout_exercises_exercise_id");

                    b.ToTable("workout_exercises", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Workouts.WorkoutTrainee", b =>
                {
                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uuid")
                        .HasColumnName("workout_id");

                    b.Property<Guid>("TraineeId")
                        .HasColumnType("uuid")
                        .HasColumnName("trainee_id");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_completed");

                    b.HasKey("WorkoutId", "TraineeId")
                        .HasName("pk_workout_trainees");

                    b.HasIndex("TraineeId")
                        .HasDatabaseName("ix_workout_trainees_trainee_id");

                    b.ToTable("workout_trainees", (string)null);
                });

            modelBuilder.Entity("UFit.Domain.Challenges.TraineeChallenge", b =>
                {
                    b.HasOne("UFit.Domain.Challenges.Challenge", null)
                        .WithMany("TraineeChallenges")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_trainee_challenges_challenges_challenge_id");

                    b.HasOne("UFit.Domain.Trainees.Trainee", null)
                        .WithMany()
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_trainee_challenges_trainees_trainee_id");
                });

            modelBuilder.Entity("UFit.Domain.Diets.Diet", b =>
                {
                    b.OwnsOne("UFit.Domain.Diets.Calories", "Calories", b1 =>
                        {
                            b1.Property<Guid>("DietId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<int>("Max")
                                .HasColumnType("integer")
                                .HasColumnName("calories_max");

                            b1.Property<int>("Min")
                                .HasColumnType("integer")
                                .HasColumnName("calories_min");

                            b1.HasKey("DietId");

                            b1.ToTable("diets");

                            b1.WithOwner()
                                .HasForeignKey("DietId")
                                .HasConstraintName("fk_diets_diets_id");
                        });

                    b.OwnsOne("UFit.Domain.Diets.Carbohydrate", "Carbohydrates", b1 =>
                        {
                            b1.Property<Guid>("DietId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<int>("Max")
                                .HasColumnType("integer")
                                .HasColumnName("carbohydrates_max");

                            b1.Property<int>("Min")
                                .HasColumnType("integer")
                                .HasColumnName("carbohydrates_min");

                            b1.HasKey("DietId");

                            b1.ToTable("diets");

                            b1.WithOwner()
                                .HasForeignKey("DietId")
                                .HasConstraintName("fk_diets_diets_id");
                        });

                    b.OwnsOne("UFit.Domain.Diets.Fat", "Fats", b1 =>
                        {
                            b1.Property<Guid>("DietId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<int>("Max")
                                .HasColumnType("integer")
                                .HasColumnName("fats_max");

                            b1.Property<int>("Min")
                                .HasColumnType("integer")
                                .HasColumnName("fats_min");

                            b1.HasKey("DietId");

                            b1.ToTable("diets");

                            b1.WithOwner()
                                .HasForeignKey("DietId")
                                .HasConstraintName("fk_diets_diets_id");
                        });

                    b.OwnsOne("UFit.Domain.Diets.Protein", "Proteins", b1 =>
                        {
                            b1.Property<Guid>("DietId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<int>("Max")
                                .HasColumnType("integer")
                                .HasColumnName("proteins_max");

                            b1.Property<int>("Min")
                                .HasColumnType("integer")
                                .HasColumnName("proteins_min");

                            b1.HasKey("DietId");

                            b1.ToTable("diets");

                            b1.WithOwner()
                                .HasForeignKey("DietId")
                                .HasConstraintName("fk_diets_diets_id");
                        });

                    b.Navigation("Calories")
                        .IsRequired();

                    b.Navigation("Carbohydrates")
                        .IsRequired();

                    b.Navigation("Fats")
                        .IsRequired();

                    b.Navigation("Proteins")
                        .IsRequired();
                });

            modelBuilder.Entity("UFit.Domain.Diets.DietTrainee", b =>
                {
                    b.HasOne("UFit.Domain.Diets.Diet", null)
                        .WithMany()
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_diet_trainees_diets_diet_id");

                    b.HasOne("UFit.Domain.Trainees.Trainee", null)
                        .WithMany()
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_diet_trainees_trainees_trainee_id");
                });

            modelBuilder.Entity("UFit.Domain.Diets.FoodItem", b =>
                {
                    b.HasOne("UFit.Domain.Diets.Meal", null)
                        .WithMany("FoodItems")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_food_items_meal_meal_id");

                    b.OwnsOne("UFit.Domain.Diets.Macronutrients", "Macronutrients", b1 =>
                        {
                            b1.Property<Guid>("FoodItemId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<double>("Carbohydrates")
                                .HasColumnType("double precision")
                                .HasColumnName("macronutrients_carbohydrates");

                            b1.Property<double>("Fat")
                                .HasColumnType("double precision")
                                .HasColumnName("macronutrients_fat");

                            b1.Property<double>("Protein")
                                .HasColumnType("double precision")
                                .HasColumnName("macronutrients_protein");

                            b1.HasKey("FoodItemId");

                            b1.ToTable("food_items");

                            b1.WithOwner()
                                .HasForeignKey("FoodItemId")
                                .HasConstraintName("fk_food_items_food_items_id");
                        });

                    b.Navigation("Macronutrients")
                        .IsRequired();
                });

            modelBuilder.Entity("UFit.Domain.Diets.Meal", b =>
                {
                    b.HasOne("UFit.Domain.Diets.Diet", null)
                        .WithMany("Meals")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_meals_diets_diet_id");
                });

            modelBuilder.Entity("UFit.Domain.Duels.Duel", b =>
                {
                    b.HasOne("UFit.Domain.Challenges.Challenge", null)
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_duels_challenges_challenge_id");

                    b.HasOne("UFit.Domain.Trainees.Trainee", null)
                        .WithMany()
                        .HasForeignKey("ChallengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_duels_trainees_challenger_id");

                    b.HasOne("UFit.Domain.Trainees.Trainee", null)
                        .WithMany()
                        .HasForeignKey("OpponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_duels_trainees_opponent_id");
                });

            modelBuilder.Entity("UFit.Domain.Trainees.Trainee", b =>
                {
                    b.OwnsOne("UFit.Domain.Trainees.Measurements", "Measurements", b1 =>
                        {
                            b1.Property<Guid>("TraineeId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Height")
                                .HasColumnType("numeric")
                                .HasColumnName("measurements_height");

                            b1.Property<decimal>("Weight")
                                .HasColumnType("numeric")
                                .HasColumnName("measurements_weight");

                            b1.HasKey("TraineeId");

                            b1.ToTable("trainees");

                            b1.WithOwner()
                                .HasForeignKey("TraineeId")
                                .HasConstraintName("fk_trainees_trainees_id");
                        });

                    b.OwnsOne("UFit.Domain.Trainees.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("TraineeId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("First")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("name_first");

                            b1.Property<string>("Last")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("name_last");

                            b1.HasKey("TraineeId");

                            b1.ToTable("trainees");

                            b1.WithOwner()
                                .HasForeignKey("TraineeId")
                                .HasConstraintName("fk_trainees_trainees_id");
                        });

                    b.Navigation("Measurements")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("UFit.Domain.Workouts.WorkoutExercise", b =>
                {
                    b.HasOne("UFit.Domain.Workouts.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workout_exercises_exercises_exercise_id");

                    b.HasOne("UFit.Domain.Workouts.Workout", null)
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workout_exercises_workouts_workout_id");
                });

            modelBuilder.Entity("UFit.Domain.Workouts.WorkoutTrainee", b =>
                {
                    b.HasOne("UFit.Domain.Trainees.Trainee", null)
                        .WithMany()
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workout_trainees_trainees_trainee_id");

                    b.HasOne("UFit.Domain.Workouts.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workout_trainees_workouts_workout_id");
                });

            modelBuilder.Entity("UFit.Domain.Challenges.Challenge", b =>
                {
                    b.Navigation("TraineeChallenges");
                });

            modelBuilder.Entity("UFit.Domain.Diets.Diet", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("UFit.Domain.Diets.Meal", b =>
                {
                    b.Navigation("FoodItems");
                });

            modelBuilder.Entity("UFit.Domain.Workouts.Workout", b =>
                {
                    b.Navigation("WorkoutExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
