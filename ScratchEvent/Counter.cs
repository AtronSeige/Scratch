using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchEvent
{
	class Counter
	{
		private int threshold;
		private int total;

		public Counter(int passedThreshold)
		{
			threshold = passedThreshold;
		}

		public void Add(int x)
		{
			OnTotalIncreased(new TotalIncreasedEventArgs(total, x));
			total += x;
			if (total >= threshold)
			{
				OnThresholdReached(EventArgs.Empty);
			}
		}

		protected virtual void OnTotalIncreased(TotalIncreasedEventArgs e)
		{
			TotalIncreased?.Invoke(this, e);
		}

		protected virtual void OnThresholdReached(EventArgs e)
		{
			ThresholdReached?.Invoke(this, e);
		}

		public event EventHandler ThresholdReached;
		public event EventHandler<TotalIncreasedEventArgs> TotalIncreased;

		public class ThresholdReachedEventArgs : EventArgs
		{
			public int Threshold { get; set; }
			public DateTime TimeReached { get; set; }
		}

		public class TotalIncreasedEventArgs : EventArgs
		{
			public int OrigValue { get; set; }
			public int IncreasedBy { get; set; }
			public int Total { get; set; }

			public TotalIncreasedEventArgs(int origValue, int increasedBy)
			{
				this.OrigValue = origValue;
				this.IncreasedBy = increasedBy;
				this.Total = origValue + increasedBy;
			}
		}
	}
}
