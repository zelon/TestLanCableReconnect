# TestLanCableReconnect
 랜선을 뽑았다가 다시 연결했을 때 연결된 tcp connection 에 어떤 일들이 벌어지는 지 테스트하기 위한 C# 서버와 C# 클라이언트

# 동작
 서버는 클라이언트가 보내는 패킷의 크기와 내용을 계속 출력하고, 클라이언트는 서버에 접속하여 1초에 하나씩 증가하는 숫자값을 서버에 전송한다
 
# 테스트 환경
 서버를 윈도우 11에서 실행하고, 같은 로컬 네트워크에 있는 리눅스(우분투 22.04.1)에서 클라이언트를 실행 후 랜선을 뽑았다가 다시 연결해보았다
 
# 결론
 클라이언트측 랜선을 뽑았을 때 클라이언트의 send 는 계속 유지되고(아마 send buffer 용량만큼 계속 쌓기만 하는듯), 서버는 (당연하게도) receive 가 멈춘다. 다시 랜선을 연결했을 때 그동안 send 되었던 내용들이 한번에 서버측에서 receive 되었다. 접속 끊어짐은 발생하지 않았다
 
 좀 신기한 것은 랜선을 뽑은채 계속 지켜보았는데, 계속 서버측에서는 접속 끊어짐이 발생하지 않았다. 이런 동작이 윈도우/리눅스의 차이가 있는지는 확인하지 못했지만, 서버 프로그래밍에서는 항상 ping test 등을 통해서 클라이언트가 정상적으로 연결되어 있는지를 꼭 확인해야 할 것 같다
 
![Result Video](ReconnectLanCable.gif)