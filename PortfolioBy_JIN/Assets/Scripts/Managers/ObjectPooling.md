# 사용한 기술 : 오브젝트 풀링 기법

skill이나 적의 인스턴스를 만들때 팩토리 메소드를 사용했지만 이를 편하게 관리할 방법을 모색하던 도중, 예전에 사용했었던 오브젝트 풀링 기법이 생각났습니다.

스킬 오브젝트들이 사라지고 만들어지는 과정은 메모리를 잡아먹습니다.

오브젝트 풀링 기법을 이용하여 그 과정을 하나로 줄여 메모리 낭비를 막고, 편하게 관리할 수 있었습니다.
