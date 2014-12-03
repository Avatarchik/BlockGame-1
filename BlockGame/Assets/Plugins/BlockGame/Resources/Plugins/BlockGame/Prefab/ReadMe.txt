Prefab 폴더 안에
필요한 블록 조각들을 BlockNum1, BlockNum2, … BlockNum###
이런 방식으로 넣으면 자동으로 인식해서 순서대로 조립 됩니다.

BlockNum1, BlockNum2, … BlockNum### 등의 블록에는 Box Collider를 컴포넌트로 추가해야 하며,
해당 콜라이더의 크기를 메쉬의 형태와 최대한 유사하게 맞춰주고 위치를 조절해야 합니다.


추가로 Prefab 폴더 안에
CompleteBlock과 GhostCompleteBlock 을 구성해서 넣어 두어야 합니다.

CompleteBlock과 GhostCompleteBlock은 위의 필요한 블록 조각들을 모두 합쳐서
완성 시키고 싶은 최종 완성본의 형태를 가진 프리팹이어야 합니다.


CompleteBlock의 경우에는
마테리얼은 일반 텍스쳐에 기본(Diffuse) 셰이더가 붙어 있는 마테리얼을 적용하면 됩니다.

CompleteBlock의 하위 블록들의 이름은
CompleteBlockNum1, CompleteBlockNum2, …, CompleteBlockNum###
이런 방식으로 지정해야 하며, 블록의 총 개수는 위의 Prefab 폴더 안에 넣어둔 블록 조각 개수와 동일해야 합니다.


GhostCompleteBlock의 경우에는
마테리얼을 위의 일반 마테리얼을 복제하여 각각 별도의 사본 마테리얼을 생성해 줍니다.
해당 마테리얼의 셰이더를 GhostShader로 변경합니다.
셰이더 코드에서 텍스쳐를 검정색으로 설정할 경우 결과가 검정색으로만 나오므로, 검정색은 피해야 합니다.

GhostCompleteBlock의 하위 블록들의 이름은
GhostBlockNum1, GhostBlockNum2, …, GhostBlockNum###
이런 방식으로 지정해야 하며, 마찬가지로 블록 총 개수는 동일하게 맞춰야 합니다.

GhostBlockNum1, GhostBlockNum2, …, GhostBlockNum### 등의
GhostCompleteBlock의 하위 블록들에는 Box Collider를 컴포넌트로 추가해야 하며,
해당 콜라이더의 크기를 메쉬의 형태와 최대한 유사하게 맞춰주고 위치를 조절해야 합니다.


마테리얼은
Preview에서 조립 할 수 있는 블록은 Enable, 조립 된 결과물은 Assembled입니다.

GhostMaterial은 화면 중앙에서 다음 스텝을 강조하기 위한 지시 블록용 마테리얼이며,
Preview에서 현 스텝을 보여주기도 합니다.

UI에서 이미 사용한 블록(비활성화 된 블록)은 Disable 마테리얼입니다.