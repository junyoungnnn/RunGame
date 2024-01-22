using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 코루틴을 관리하기 위한 간단한 캐시 클래스
public class CoroutineCache 
{
    // float 값에 대한 비교 및 해시 함수를 제공하는 내부 클래스
    class FloatCompare : IEqualityComparer<float> 
    {
        public bool Equals(float x, float y)
        {
            return x == y;
        }

        public int GetHashCode(float obj)
        {
            return obj.GetHashCode();
        }
    }
    // 특정 시간 간격에 대한 WaitForSeconds 객체를 캐시하는 딕셔너리
    private static readonly Dictionary<float, WaitForSeconds> timeInterval = new Dictionary<float, WaitForSeconds>(new FloatCompare());
    
    // 주어진 시간 간격에 대한 WaitForSeconds 객체를 반환하는 정적 메서드
    public static WaitForSeconds waitForSeconds(float time)
    {
        WaitForSeconds waitForSeconds;

        // 딕셔너리에서 해당 시간 간격에 대한 WaitForSeconds를 찾음
        if (timeInterval.TryGetValue(time, out waitForSeconds) == false)
        {
            // 해당 시간 간격에 대한 WaitForSeconds가 존재하지 않으면 새로운 객체 생성 후 딕셔너리에 추가
            timeInterval.Add(time, waitForSeconds = new WaitForSeconds(time));
        }
        // 찾은 또는 새로 생성한 WaitForSeconds 객체 반환
        return waitForSeconds;
    }
}
