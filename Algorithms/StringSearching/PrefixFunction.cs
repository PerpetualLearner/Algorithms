namespace Algorithms.StringSearching
{
    public static class PrefixFunction
    {
        /// <summary>
        /// �������-�������.        
        /// </summary>
        /// <remarks>
        /// ��������� �������-������� ������ ����� �� ����� �(n^3). 
        /// ��������� ������ - ������ �� ���������� �������� - ����� ������� ������� ����� ����� � ���������� ���� ����� ����������� (����� �������� - 1) ���.</remarks>
		/// <returns>
		/// ���������� ������ ������������ ���� ����������� �������� � �������� ��� ������ ��������� �������� ������.
		/// </returns>
        public static int[] Naive(string text)
        {
            // ���������� �������� ������� ������� ��� ������� �������� ������.
            var resultArray = new int[text.Length];

            // �������-������� ��� ������ �� ������ �������� �� ����������� ����� 0,
            // �.�. ������� �� ������ ��������� � ����� �������.
            resultArray[0] = 0;

            // ��������� �������� �������-������� ��� ������� ��������, ������� �� �������, ������� �� ���� ���������.
            // i �� ������ �������� ���������� �����(! �� ������) �������� �������� � �������������� ��� �������.
            for (int i = 2; i <= text.Length; i++)
            {
                int maxLength = 0;
                // �������� �� ���� ��������� ������ �������� (�������� �����������)!
                // j �� ������ �������� ���������� ����� (! �� ������) �������� ��������.
                // j ��� �� ���������� ������� ��������, �.�. �� ����� ����� ����� ��������.
                for (int j = 1; j < i; j++)
                {
                    bool isEqual = true;
                    // ���������� ������� � ������� �����������, ������� � ������� �������. 
                    for (int k = 0; k < j; k++)
                    {
	                    if (text[k] != text[i - j + k])
	                    {
		                    isEqual = false;
							break;
	                    }
                    }
                    // ���� ������� ����� ��������, ��������� �� ����� �� ��� ������� ���� �� ����������� �����?
                    if (isEqual && j > maxLength)
                        maxLength = j;
                }

                resultArray[i - 1] = maxLength;
            }
            return resultArray;
        }

		public static int Search(string pattern, string text)
		{
			var prefixes = Naive(pattern + "#" + text);

			for (int i = 0; i < prefixes.Length; i++)
			{
				if (prefixes[i] == pattern.Length)
				{
					return i - pattern.Length - pattern.Length;
				}
			}
			return -1;
		}
    }
}