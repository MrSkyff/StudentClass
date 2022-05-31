    interface ITask<T,K>
    {
        IEnumerable<T> Tasks { get; }
        T GetObjectTask(int id);
        void AddTask(T task);
        void DeleteTask(T task);
        void EditTask(T task);
        //Оценивание и закрытие задачи
        void MarkTask(T task);
        //Отправка на пересдачу
        void PullBackTask(T task);
        //Статистика по оценкам и предметам
        K GetStudentStatistics(int studentId);
    }
