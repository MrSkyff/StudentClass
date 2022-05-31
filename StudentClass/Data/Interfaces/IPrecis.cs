    //Конспект
    interface IPrecis<T>
    {
        IEnumerable<T> Precisies { get; }
        T GetObjectPrecis(int id);
        void AddPrecis(T task);
        void DeletePrecis(T task);
        void EditPrecis(T task);
    }
