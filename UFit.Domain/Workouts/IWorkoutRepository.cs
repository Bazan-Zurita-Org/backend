﻿namespace UFit.Domain.Workouts;
public interface IWorkoutRepository
{
    void Add(Workout workout);
    Task<Workout?> findById(Guid id);
}
