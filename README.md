# Dungeon and Signal
2022 KHU SWFestival 게임 부문 출품 작품   
   
데모영상: https://youtu.be/E9cJD2p3YWU

### 게임 개요
게임 장르: 오토 배틀, 팀 빌딩, 전략 시뮬레이션   
개발 언어: C# (Unity 2021.3.6f1)   
대상 플랫폼: Android   


<h3> <p align="center">Poster </p></h3>

<p align="center">
<img src="https://user-images.githubusercontent.com/99636089/202706444-ad42af45-a181-4e84-9f29-e99c4dc2014b.png" width = "50%" height="50%"></p>

### 게임 소개
Dungeon and Signal은 점점 강해지는 적과 싸우며 강한 아군 용병들의 조합을 맞추는 게임입니다.   
각 용병은 개별 <b>성격 유형(MBTI)</b>을 가지고 있습니다. 용병들 사이의 성격 관계에 따라 팀에 버프나 디버프가 주어집니다.    
팀 전체의 성격 관계에 따른 전체 팀 버프, 전투에 참여하는 유닛에 따른 전투 팀 버프, 같은 적을 공격하는 용병의 관계에 따라 추가 전투 효과가 발동됩니다.   
이렇게 성격 조합이 전투에 직접적으로 영향을 주기 때문에 매우 중요합니다.   
하지만 전투에 참여할 때마다 용병의 허기가 줄어들기 때문에 하나의 조합으로 계속 진행할 수 없습니다.   
전략적으로 팀을 구성하고, 전투에 참여하는 용병을 배치하여 던전을 모두 격파하세요!   

### 기술 요소
1. [BT구현] 유니티에서 효율적인 전투 AI 구현을 위한, Behavior Tree 기능 구현.
<p align="center">
<img src="https://user-images.githubusercontent.com/99636089/202720097-54eb088f-2713-45e7-b23a-31a2e835be27.png"> </p>

2. [전투 시스템] 전투 맵의 경우 노드 단위로 구분하여, 가까운 적 탐색, 이동, 전투 시스템 구현.
<p align="center">
<img src="https://user-images.githubusercontent.com/99636089/202709877-f14688b1-0fe0-486c-978a-21342bd0b362.gif" width = "50%" height="50%"></p>

3. [절차적 맵 생성] 새 게임 시작 혹은 다음 스테이지로 넘어갈 경우, 알고리즘에 따라 절차적 지도 생성.
<img src="https://user-images.githubusercontent.com/99636089/202722466-7c79d658-bb43-4a8d-a408-7b6e9a5f9314.png">
<img src="https://user-images.githubusercontent.com/99636089/202722473-dd9c8c9c-4343-4184-ba10-50b591884dec.png">
