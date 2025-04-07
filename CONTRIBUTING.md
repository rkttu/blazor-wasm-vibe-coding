# 기여 가이드

이 문서는 이 프로젝트에 기여하고자 하는 개발자들을 위한 가이드라인을 제공합니다.

## 개발 환경 설정

### 필수 요구 사항

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) 또는 [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/downloads)

### 환경 설정 단계

1. 저장소 복제
   ```bash
   git clone <repository-url>
   cd CalculatorApp
   ```

2. 의존성 복원
   ```bash
   cd src
   dotnet restore
   ```

3. 빌드
   ```bash
   dotnet build
   ```

4. 테스트 실행
   ```bash
   dotnet test
   ```

5. 애플리케이션 실행
   ```bash
   cd CalculatorApp
   dotnet run
   ```

## 개발 워크플로우

1. 이슈 선택 또는 생성
2. 새 브랜치 생성 (`feature/기능명` 또는 `fix/버그명` 형식 사용)
3. 변경 사항 구현
4. 테스트 추가 및 모든 테스트 통과 확인
5. Pull Request 생성
6. 코드 리뷰 및 피드백 수용
7. 병합

## 코드 스타일 가이드

- [C# 코딩 컨벤션](https://docs.microsoft.com/ko-kr/dotnet/csharp/fundamentals/coding-style/coding-conventions)을 따릅니다.
- 모든 공개 API에는 XML 문서 주석을 추가합니다.
- 각 커밋 메시지는 명확하고 설명적이어야 합니다.

## Pull Request 프로세스

1. 새 브랜치에서 작업 완료 후 PR 생성
2. PR 설명에 구현한 내용과 테스트 방법 포함
3. 모든 CI 검사를 통과했는지 확인
4. 최소 1명의 리뷰어 승인 필요
5. 모든 리뷰 의견 해결 후 병합

## 테스트 지침

- 모든 새 기능은 단위 테스트를 포함해야 합니다.
- 테스트는 의미 있는 이름을 가져야 합니다 (Given_When_Then 형식 권장).
- 테스트 코드도 프로덕션 코드와 동일한 품질 표준을 따라야 합니다.

## 질문이나 도움이 필요한 경우

이슈를 생성하거나 프로젝트 관리자에게 직접 연락하세요.