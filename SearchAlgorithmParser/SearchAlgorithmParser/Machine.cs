﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public abstract class Machine<T, S>
    {
        public HashSet<T> EndStates { private set; get; }
        public virtual T StartState { set; get; }
        public S[] Alphabet { private set; get; }

        public Machine(S[] alphabet)
        {
            this.EndStates = new HashSet<T>();
            this.Alphabet = alphabet;
        }

        public abstract bool Validate(S[] toBeVerified);
        public abstract Language<S> GetLanguage(int length);
        public abstract bool IsMachineValid();
        public abstract HashSet<T> GetStates();
    }
}
