﻿namespace HashTable
{
    internal class Program
    {
        /**************************
         * 해시테이블 (HashTable)
         * 
         * 키 값을 해시함수로 해싱하여 해시테이블의 특정 위치로 직접 액세스하도록 만든 방식
         * 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑
         * 키 데이터(숫자, 문자 등등)을 해쉬함수로 해싱(인덱스화)
         * 
         * <목욕탕에 비유 가능>
         * 목욕탕에 가면 내 키번호에 해당하는 칸에 가서 물건을 보관하고,
         * 떠날 때도 키번호에 해당하는 칸에 가서 물건을 찾아온다.
         * 
         * 해시 = 목욕탕 주인이 키를 주는 행위
         * 키 값 = 번호키
         * 인덱스 = 보관함
         * 데이터 = 보관할 물건
         ***************************/

        // 해시함수의 조건
        // 1. 입력에 대한 해시함수의 결과가 항상 동일한 값이어야 한다.

        // <해시함수의 효율>
        // 1. 해시함수 자체가 느린 경우 의미가 없음.
        // 2. 해시함수의 결과가 밀집도가 낮아야 함. (덜 겹치게)
        // 3. 해시테이블의 크기가 클수록 빠르지만 메모리가 부담됨.

        // <해시테이블 주의점 - 충돌>
        // 해시함수가 서로 다른 입력 값에 대해 동일한 해시테이블 주소를 반환하는 것
        // 모든 입력 값에 대해 고유한 해시 값을 만드는 것은 불가능하며 충돌은 피할 수 없음
        // 대표적인 충돌 해결방안으로 체이닝과 개방주소법이 있음

        // <충돌해결방안 - 체이닝>
        // 해시 충돌이 발생하면 연결리스트로 데이터들을 연결하는 방식
        // 장점 : 해시테이블에 자료가 많아지더라도 성능저하가 적음
        // 단점 : 해시테이블 외 추가적인 저장공간이 필요

        // <충돌해결방안 - 개방주소법> -C#에서 사용
        // 해시 충돌이 발생하면 다른 빈 공간에 데이터를 삽입하는 방식
        // 해시 충돌시 선형탐색, 제곱탐색, 이중해시 등을 통해 다른 빈 공간을 선정
        // 장점 : 추가적인 저장공간이 필요하지 않음, 삽입삭제시 오버헤드가 적음
        // 단점 : 해시테이블에 자료가 많아질수록 성능저하가 많음
        // 해시테이블의 공간 사용률이 높을 경우 성능저하가 발생하므로 재해싱 과정을 진행함
        // 재해싱 : 해시테이블의 크기를 늘리고 테이블 내의 모든 데이터를 다시 해싱 

        // List는 숫자로 접근하고 싶을 때, Dictionary는 문자로 접근할 때 사용

        void Dictionary()
        {
            Dictionary <string, Item> dictionary = new Dictionary<string, Item> ();

            // 추가
            dictionary.Add("초기 아이템", new Item("초보자용 검", 10));
            dictionary.Add("초기 방어구", new Item("초보자용 가죽갑옷", 30))   ;
            dictionary.Add("전직 아이템", new Item("푸른결정", 1));

            // 탐색
            Console.WriteLine(dictionary["초기아이템"]);

            // 접근
            dictionary.Remove("전직아이템");

            // 확인
            if (dictionary.ContainsKey ("초기아이템")) 
            {
                Console.WriteLine("딕셔너리에 초기 아이템이 있음");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public class Item
        {
            public string name;
            public int weight;

            public Item(string name, int weight)
            {
                this.name = name;
                this.weight = weight;
            }
        }
    }
}