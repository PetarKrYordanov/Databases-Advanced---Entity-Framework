# Entity Framework Core: Exam Preparation 2

Exam problems for the [Databases Advanced - Entity Framework course @ SoftUni](https://softuni.bg/courses/databases-advanced-entity-framework). Submit your solutions in the SoftUni judge system (delete all &quot;bin&quot;/&quot;obj&quot; folders alongside with the &quot;packages&quot; folder).

Your task is to create a database application using **Entity Framework Core** using the **Code First** approach. Design the **domain models** and **methods** for manipulating the data, as described below.

# Stations

Create an application which models a **train transport system**. The mainidea is to have **stations** between which **trains** travel. Each **travel** between two stations is calleda **trip**. People can buy **tickets** for a specific **trip**. Some people might not be registered while others may have a **personal card** (in other words – some tickets may have **buyer&#39;s information** while others will not). For more details about the **models** and their **relations** read further.

 ![](data:image/*;base64,iVBORw0KGgoAAAANSUhEUgAABLoAAAJ1CAMAAAGeL1mfAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAE+UExURf///2RkZPDw8Mh4KAAAAABQoPDwyHgoAAAAUKDw8PDIeCgAAKBQAAAoeMjw8PCgUCh4yHgoUPDwoFAAACh4eFCg8MigUAAAKHjI8CgoKKB4KKCgoNDQ0K+vr///qlUAK4DU/8/Pz3x8N4qKAFUAVar//7S0tICAAP//AC8vALm5uX9/C/n5AKpVACuAgKSkpI+PFtSAKwArgNT//wAAKzw8PEhINuXl5aenC46OjouLAABVqq6urv//1IArAFWqqlUAAFWq/4CqgCsAAP+qVYBVgAAAVf/UgCsAK9SAgCuA1ICq/ysrgIArKysAVYArVStVqlUrVYDUqoCAVdT/qqDwyCh4oMjwyHig8AAoKMjIeKBQUKqq1KrUgCsrVYDU1ABVVVCgyMjwoFUrK1WAgKpVK6r/qlVVqisrKwAAAH3O5xUAAABqdFJOU////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////wC85NzjAAAACXBIWXMAAA7EAAAOxAGVKw4bAABNfklEQVR4Xu29i3PbSJbmmwZTpmQRktoqjVztKJAui2F2xaij1Izq7gqZUZKDZfV47N5+7eve2d47997Z7f//L9hzMg9IkARIvBOP72eTABIgmDr48CETTGQqAOrEO4BsVj/6xBt6A8lFDLJZ/Xgv/ZHnnQ5eSUa2kc3ACm9Gh1PmW8azNMi2feFh6ctca5FTNUozjqJkJkrpGfPWmg3UhCfmbT+eN/KOtGTJUn7GZFoU9xnzPD1T/5CFNc9mHEFZKIPIvoLxJBjLfGZwKA8SaA7w+IucK4hYVhqUscmG4SFizkHGstLVjJkC9T5ku+wUzZgt9CQj2zGSkoxsZymasZE+O90smW0i2zGePqKEE5seh2xnKZoxmSaxmTFfExeSjV1kO0vRjHnv1M2espKnqMIqHPqq2IyJVBOxW+2SLmLyTjGZ7im4x2bMxjIZu9UumTJm3pPZXC9L3vnFNdUvTrzzV16clu1Wa14bbMZu55OJVvpI61u7MkI0Szs72WJz/aGtLYlbZY0YHckvZiGGzS8xSzPl/cosJbH5mQjVHcp07M3YWD387I/9z2o5sokRnGaMs5bETsY0VRUmwXVgUjZJ/JLgcZl0i+xAxpLZydgeDq2PY2/GxlQbpTrpVI3pLdiMhdOM7UOyRNaiNc9TthOPe3LG5vN7NVdqKYsRCmbMkvzFlkPr49ibsbuxup8QNmWT5IztBi5PxhJJEzF77dBmXl8sbsdjpefq2qyPUnvGwm1sBvcg25WC/dJJkFRoiGasVrJErFYanbELOiGHdnEHdxkT3SbC29hN64W/lC+w1wkhi2ZMspqMbFcK5ksnSvvjYOJPdssMmxnT51oPtb68Gr3U55KbCLJdKRw6TM4iloZIxmQuntozFsIZS199q5FDX4yMbcNfPFlS2SIBdxk7hGxXO0UPpWQ/EdksO+aTwwczH8fBjGnv2DsaJt5gk82yc/CLZZqEvV+SjGyWHf7iuIpuyMGMH9pgtud+2T6KRowztns/KULeFi0ihWRkuyRkq0Rks/px980HMBlrYgOkRkdsT+HEHc2N2AFkMwAAAK1FDD2RXKXVErC/myY3BHCWL9/Tz48pX9fxeXOVr0N1Hmf5OlBWaGy8tLatG/YjW5dHY48jvcaL8dQu7dIO3ctJuoGsKpmM+YoxE1lVGlaunC+9GE+Cp2AcxNyy3c7XxfnZVjsmWVUyGeMl0+pJny9uJc/h2Q5q2a3kLSZfY62ChLs663zxXBPj1fR8BSoYXwTjSbW3WroTr6axOo6PN2a5KTQ5Xk0E+cpGS/Jlis97kM2qZ+ubTBlnD7KZQZISkc3ysZuvi5d2t7HIZobh8Z6aMyGb5aPAkaEikh7tyZpslo/tfL2TaRLrVvF5EJUmI9sVipf6XnHTyyxIJPkB11jKyVd2vHPt6zPtHY3O+NEIyc2anXxt/JJ7qoPP+kkF+55zyEe2ck4B5pMMeZ9luG9SMF8ZKRavp7uP4/EoCJafJaE0ajuOUzWeKH03TVkt4HxdLj/YhRhKy1dGsscrKsiFfdbe57dyT8li+TrI2lMCws6lgj81mRPjaWwLkYL5yk2heA0CpUnOWWu45f6WniNe9pJh558m49vxPU3u9zVAzMFGvnSmGNn8JSObFSO6l3kFV8a8lPPXlU8L8jXOWNirFMmXSDYRu1WNRL6RTsqHxKcGIkhWE5HNirG5l4dg7AcTvb9voXNvxE8KH2mfKkYxhWLZrBg59iJfn4hsVow8e9n/GUf5mmn1g8zG4y5e+0G+YljeUWkiHmf5ktMuEdmsGOXsJcqhPUruE5Gt7CQrd8kX00N7vBx4+kwvDrR7z5mvPRzao7kjsge7Vf358t57e1vNa9PqPW++kkv1B/P1o5f086jF3ALMkS/RQSKyWRKyVRKylQu8/J2uVYoXXE+a2Obd5bHaB/KVBTnvEpHNAAAAAAASkWJDbta/2fQDz/Nfaq1Hz7WvvYH29PO4m6HJ9C9exehbvF7T3yyzuehhvMydkSy/j0d5phv5fHplHPoN/hC905dMmUuZZqGv8RqPl3fj+I4L99JHvy/A3njJNodoVchDfRnTtvLS1vunqdr67I+X9i7OtXd2pPWVBCeGpsdro/ywjpcejjVFiGYCmgs+TXnpIMX11fhTOjZeeUn8Y0mwnvLevqHZA0qlXTS6SBIbr8mpmQRZm1jGxcuk2XiZwvABpbYyXvt7uEomMV7ExhclE7eLJlH5+bgdL6k7iIh2tIZ4yRT62qVv8bLX9PykiVdwu/wwTW4q2ap4VUGMvvZdIBEvmab8IsRLph0B8coG4pUNxCsbbuN1cJyEQ8h+6sN1vEaePju7OD7P8jNnBNnPNrI2P7KfXRqhr+Tx9A4h+9mGb076+oU+Pg28k2PZNguyn10cx0umeUmMlzQ0z0tz4+V5v6PpzTRf82dP61nYnUT0L/FM03gmzW3hXVLGS8SYm7jY1KavrXj9yMvpfnbYJW28yHU1P+JxdnZ07PknPtvx6t9hmhOvosh+dtmM1yZnMk1NtnhppcOVQzUnJUyCQA0n84kKVBDcpOlGIzFeMs17aztlvAre/2rS+Wihs3Gig/3PssaRHK8Vs5nWBdubNC9eeUn5eWf6Gt8p9XD7m+vJeHg9uTXn4/4HrIRD8Zpwt7JyXmcRQWPjJcaXG9kPkzRvSeyPN5as8fqLP04YKHMf+fX1sB7M0n6rJlGYOZKaSYgnfbyykTVe+UgVr42srOLlK/2g7gNufMC9uCz0ncwFi59kmzgOxSsI/EAH6itZTE3ueGVqBZY/XnmJ/buonBJJz3XtyhqvR/N+r/4+ptIQHyazfIgC8VrZSzYTSPq7Uv69iaSNl7hoTmLlki5eOTkUL6oPTejie/ugP97P51M1n87966nRwF6KxrsAtcRr75fkwGW8kjArzSbMqVaBvrnNeJsiKV4dohZ9dQjEKxux8RqqCblx9ms/9JUNxCsbSfGSAk5+ZD8NICFeVCQKFmMVjMfjLxP6T8WmL7JqD8nxOt25H/zCpgzM+yFkPw0gIV75SIzX86OBvvSGA+9ID597vvYu+Zb66KWnH7yhxGQfsp8GUElWduIl05x0P17yuyGjZ5rq294/f0fp6R6z2KHz8doG+soG4pWN8EsmarE09yZkOSXQVzYQr2wUjJeUSXIju7HUGq/Pk0me54SLxkvrF/Rnn9q/PjuyG0ut8cpJ8Xid+/pan51pPfROMjcFlN1Y+hCv1Vtu1mP+1BqvQP1p8iV7mbVovDzve8pCcHcnCUWoNV45ca0vrdf66gGF49UzJF7B3djepjKJIBHoKxuIVzbCeE2m4//5v8b5Wn73CegLAAAAAAAAAAAAoFm0r1cWpyBcmXj23I7Rwd2m6MShMvcg++kJtssf7m5Gv9Qej/rMg51kQPbTE0y4Bt4rXw/OvasrCtvAe56l4wnZT0+Ad2WiaPv3gg98tw3uHqmIQvoXrnfvaJr5MU2hh+r6kaapevaJ4XWze6ovm8LexdGSZ4uL0/gLR7OsHuHKRPvCldHCehuu+XwaLG/8dX8/qeivuuaTILi5R7j2Ual32WrSQWRrovnhkiznpW/hkmleDoQr1b0N2ZpodrgiXXg+HdGb7SBjcWyegNjflVvIoXBdevr60FMzsjXRyHBJEdpEaqWu+WSigmA8noy5E9xATYIxwrVDGK7h48Ncc28Pw/GTP9HBJ72/47uQErwrsovWhCsv+8O1etsHwkVw1dvz3rylEBxwQd6F3NboZbhMF34zgibmIbb9LvhaNmUkqbGE4VrKNOtjgbHh4jerLgoAhWu/C0bU1XjCcP2GA6XpwjhRT5KUisRwMZm9q/GsT8ZVd92219CU9DZc+UC4MpEqXNYQZdTbHdtHuIRVuCZ311RTWJgeH6hYwX1mr0G4hDBc+0G4BIRrG4QrE30Ll6l7FED2E2UnXBP1N60SfwRoU7iqYDdc9/tq2QiXEIZL/XFfHRvhElbh2gvClQmEC2QA4coEwpUJhCsTCFcmEK5MIFyZQLgysT9c0kAjN7Kb7rA/XHInIzeym+6QIlyZe/1dI7vZQVbnRnZTP4fC5b+81JfphuiOQXazg6zOjeymfg6Hy9OX3lXZ4dJ64HkveZNcPX3LbuonjXdd2kkOZDc7eN7Z6OXZyxEdB45bZmQ39bM/XPvX5ofD5emXz0+0r3+ZQ7mym/pxEy4ZGyc3spv6ORAuz/uVzOYkviduIw93GsnPwXAVGT+fopUQLs97b8KVe8cpkKJyfmQ/UdycjBSu8vrbT6LS3xljqTBcP3K4bm8loQrW4VpdTHyZpkP2E8VRuFZvFfLMu/DO/ZEeavpPJT0qD/naP9f6Sp/pKwnJPmQ/UZypqwiylwOQujSx9E742YpXmgrEpn+XhwtNL9nVPmQ/UTYCIpdpi0kwycRy/Df11fiDUqfk3uPbOc0VadFbk7o2yF68k/1E2QjXzgaRcAX0j5+tWfLDNTeTSaFrmoQryPhAZjYqbYHDJIeLGcq0BMJw3dExMAlV4DhcJRKGS42DxWMl7fRnmsIlvZRkfWZdaFy4KmSmNfdS8juavZm6DtelTPNSfbgIhyfj+H4+n5sqC78mY/9+atJz0vVwTe75fR2uSY6BAyNIuCKP6Iz9QjuMo3NWr+4erjU/+HsTPEwnOlD5BjhOwEG4pMCWE9nLLmG4VmR6FCwlYbjGio6E1oush6J56qqUVbgCFnD2Al62cHF9K1xrikbm+2xh/nQ1x8/OZ6fWcOUlf7gU13/MA5R0lKgWxLep7BzCFSFcq9XDXN9RuDSJyh+PtbqXuXzDz4fhmnwYf5jmHMH+IO7CVQZyo4N79NOrcFGR5CafQA+zDtc4Ug1KX8J2G641eqUuoppQMWG4Fp8f7uifejr6tFiOx/6Rn66I3ZRwyRftfFvJhOHyFw+3D9wZaKCWdxSu+5RF7Pzh+rtMU/Udk4Jaw5WX/OEiJuNHpSlcVIJ5KHxXb3+4SjomRX8JKhSuUpFwcfBvlJrTP/X0EKjF8oGCVemvaQWpJVwbdSlOWL0tBuqRg0WQuZC1ULgq/TWtIPWES6Yr1jFrGY7CVQzZiwOkOUAMvDb8O8fjueafzXLeVi8p6k0jUV3j8ZJ/Nst7yepbuAqCcGUC4coEwpWJvoVrHnBdfpz3x7LeqSugAvcwd1Wxd+EqRm/CJcXonMheoK5s7OxGwpkb2Y1jksK10PamQd6mRT0Ll+KfyMxvZ3zblqpCQbYfOWPCtdv0UVrX8miKB5HdOGZ/uLhfbgoXN2UIsrVi2w2X9l56vv53PeImyfQ645En9RFNj9M0SpbdOCYxXAWJDdeZ7/nXp96rIz164XkXQ+/q7Fqfk7pSNH6X3TimvnAVRHbjmKqysRuu1VubqS9crBCEKwH5ud8ym7GtfzejbwvUV7JFK6nleFO0WF2/53CV9TOvG2o7PcwX4WRMC8KVCYQrEwhXJiRcwcfxfMrtI0xi66g9XOp6Xl1zuMqpO1wtp75wFUP24hqoKxO1h4tHTqwbUWh+ZD8OwrUIVLAwKfUhf3R+ZD/1h+uWb/9X8mzxHrzn+oTvcO8dhnIfsp/6w+UE/p3g2OPeJU7Vq2O+O5IR2U9fwnWuT7T+2tP8Q8ER/1KQEdlPX8Il993y4jBcLor0Bf9IVtfM+m394XrkYcFMUm14yntv/9BcB8sO/rluvlsHYbjUbf23Uylc3/NXT/NVVyPeVRurcDmAwvWjCVdeddHJGNvlXXXINSY3sptcFDxKVA7RdYfLJRLx/Mh+ekJhdclMTwj/3NX4vNnoa7gmcx7nn5thZaK34VKLX5tmWLKcEnhXJhCuTCBcmehruHJWv3obrkAt/lf2x3ZwMmYC4cpE78JVFNkPAAAAAAAAAAAAAAAAAAAAAAAAAECTKTx2fVFqe5QI1A/UBaqD1XW703vmufaen8i85w1S9d6aE6irw7C6Rr73kvu11frVyH+ujZoe9CsewdMk0rJO091tLqCuDhNV19FKXS+1PmK5+SbR077WF1YMpQN1dZhnBccsKIh6DXV1mGcl9fudF6iry5C6yEK+ffutLN/QK9PYDgWBurqMVZc3Cy3sJphAXaAkRF3fhE+O3aihrldd2g4hpKVDsCZhswhy04BylxZ9NQ48q1kUlOqTgbqKAnUlA3UVZUddG4Wu6muQUFeXiVEXyUnryTiYBJObYAp1gdy09srINd3yiM0F1FUUqMsAdVVCi9U11FqHbYOe63WDoTxAXZXQau/SZ96l9kfcoEOfsdjOuNFQHqCuIsjN5zWSvqOuz/QaXqulfjzVwWR8+qhu9Vh9UiqYUJrSx/Sfivr6q5JGuiisrgt6H12zukhiJ2RiZ0YuGYG6ihATKPPzS4x3DQMSjq9MnZEqkPy74+KR1UVp5v7EOJiOaVE2LwjKXR0gMVAproyLe5mpggLqkpkyVBCfC6grJUXUVSlF1GVtB+pyTnfUpWd2oB2jru/+efad/eOKlQVtLmjPG7+mQ10pya+ugMpcFZJWXavtjLr0TLzrh9/TX2bVVaQsSHunXW6rC6Qktbp8Lr9TYX4xX04f5h9t0f6IK43VkFldITWUu0BKUqvrbqJO1VBdL+d3tsbI6gr+LGvLB+rqAKnVFcu1TCsA6uoAe9Rla16OKF9dMeXEw+UxqKsQe9QlM44oTV10DffVz+o4mJji4kd7VX+Ya/WRVvjq/mmePDwg1FWIXqhron6jrsMfGJbXi4sBz9PSveJ/e1qqQV2F6L66CgF1FaKL6ioPqKsY8K69QF2F6Ly6hlrnHDiegboKUfz0dsxB76JS/fQ/UWmeSvSLzL8IQV2F6IO61K0K/qrn6oFeGYG6CtF9dRUC6ipEB9Ul01KAugrRRe8qE6irCN1TF2gOUBeoDqgLVAfUBaoD6gLVAXWB6oC6QHVAXaA6+qwu54MESj66C9TlEMlHWp65RvKRnn6r67kmuPu4fJ17FUXykRb5lDskH+npu3eZQQLPPH12eaz0VcGOCrMi+UiLfGpwxO88tGHdSD7SA3XZISjPLrl3wrw9FOZE8pEW/gidCZTlF1pTrnmUTNO14ll1Y7BuIPlIT6/VJd0tuiK3us6v2btOL/hsIJGdeA+VjcG6geQjPf1Wl8w4Io+6nCL5SE/P1UUhe/P+jSwz1Q7xsImNPY+1lY7I4XVy2KCuLFh1vV4PQan8Kvtd2cHjLsdmMz0zxhBB1m8DddVOYXV5b8MY3Kj7etVl3ne9K+mYkLo875vZ7L3dJJiaR1LqI7tWEj/h/FZjStV0sNy1V13eD7+l9bxJML2BuvJSh7rkq9yQR10h2Q90CWT/0sRPkLqG6wFRiNOTzTvaVBm+GvmyUAHwrm26pa6XpJ8X2nu48rzlMd9W0WfD44U+OT2iN3P/zqiL5k+8Aenw9CrQPC2HKtWVMODDg9660DzpI3vtiVQlyxuaMlFFMt2mW+oidyJRmVvBX1/zbWEZFYUH3jkh6bF3ndPkFb0GWl+MtPZ5KvIoSGF1efLb6w6yfkddf+RSMvcQbV6m3y89Z3WFXX/dcBq9QV0pSfyE6xvZaT1pj7pkmsiOd51qHtM0mCz0T1ZdQx4BaaF/Pbm7H6tblhqpSw11I9TFmRmf/o1OgYvFtulWwsGA7pD4CceFEs+FumomKYOJ6esVPMeuap22JC89xMGA7hDzCXsDhkJPlydnN7Khrl1aeGXcYWbvIFt1ObuRDXXt0j51xRD1Lmc3sl2oa6yWW72OR82aL0TlkpTBxPT1ioN/WxWU+KWOT2w36qJaodZUkFlM7vS1qRvayuKDvmZ1mZJ+MOGlMkhUkUy32aeuS5ky5Z8HloMBTY/jG9kur4x1FS8TVSTTbbbUtfCVGqnPPHATnwP+cnoXjrLzs/qo/AV3xW83L4eDAU1PD72rbhJVJNNtttS1JJO6pcl64KZbdcs1SB7t91rdk7rsxmVxMKDp2Q79w7wyx40D6trlYLnrVlc52m+V6horn9UlRY+x+iLpFQF17SJlBldUqy6y3aEWdQVFuulOQ3nqkthE4E9wvTjmT/TV8Fot9f/QR+Pgg6a5x1NNJxX9tePTRyrFPOmjzbQiQ9dmV5fMJG9SKSV+qeMTu0R12UkMMeq6N1d/+V2Ryy9mMjYj1NLqxSNZ+EZakaFrk3KWmL5ewXORnvjraUiYHMnM9FBddZOUs910clqtd7yLRc5SL6bx9CRHMjNQV+Uk5Uyacqyw2lI6QV1/1fNgyj+8mzUVkhzJzOyE/u/cfsBcPrbYTSmBPqsriQ6Xu+7UgHS0oPIGv/iW9u2SEsytbXJmdugyvdmpusIb3+a8id4FL5esRwul+rJwoa7F5LN6mAdUbF+qkb0Fbi49/vJ+OR2pz7JZaWQ9WlBXWbhQl2/qhCwoNZ7aW+BGXWTK5q542WQ9WtvqelBPZiGucLJeR2tLqlJmze8e2v9MkAQjOSaOT6D0R0vHluqtZuifJnXxw2d802Rsf4bndbbUYgot5Tybljq/3aGQukTIbtjOWfJfEq+u2nHypW7pjncl/yUC1FU78oxHFuST2+paaB0dwLG8J8uSyK4ux0g+ACHBiIsJXWfoteNdXHDhsowpyJf3ZFkSWdUFGsQedVli1cXPl1l1lfZkWRJQV4vJrq6agbpaDNQFqgPqAtWRWV1/UP9i7zlWW9xaAXW1mMzqUuojqcv+Lk//HrYebiwdqKvF5FBXvUBdLQbqAtUBdYHq6Jy65PcYd0g+AJFdXdyea3z6qB/5uTOqOPrBX/T/o48WehJ88M07N1UorS82qKvF5FQX1xf5xgSp614WTds7884JPFcKOdSlfe/cHmkioY/agT7zIoNSldeTLdQVIbu6aia7us651+2Xmgei0pp1o195p1fDo+eSpC8uLzzTXzItXNOG59e0FW9bCpIPQHRQXdxT8rF3qW+592PjZDx2nqiLTEufkbp4ejLS56wub6gHx2bbMpB8AOKwuiRozpB8CE0vd+2JZA85qK6GkUJdMuPkj4K6NuiOumYzbu7I6vK8N2/fvrF/VElP+qQF6tqgfepKgLtJphcVnvji+I/v6S+y6jJPxNUF1LVB29R1EKsuLgGJuuroPGIF1LVBF9UV4uCPgro2gLpKBeraAOoqFahrg66rK6CKZFk/SqUA6tqg8+qaLC7CLq5s/xF2XUVAXRt0XV01A3VtAHWVCtS1AdRVKlDXBlBXqThUl/xm4Q7JR5TOq2twx4O3jLkhbQ04VJf9hcIhko8okuYsJqWzpS6qJfLzl6YhbQ00Sl0lNVhLi+QjiqQ5i0npxF4ZF5UOPBXBqbq4Ue5zrf2R1mdDeukzT+sLb3ikj7kZroigMiQfUSTNWUxKJ1ZdteHau/QFt/T2l9eePvFIX7bNNy28hLrKoN/qconkI4qkOYtJ6fRYXTLToD9c0pzFpHS2gxxMlmoU+Move4jiWHqtLq25CedMOt5lJCPOYlI6u+pSf54G94r/VY9bdXneN7PZe/uHO2ryLe3PN3EWk9LZPYVvJ/WF2bW6vB9+SxngPJQ0uENawj+cxwzYwVlMSseWMF3hMJK7p1WdkLrMZXGmZxKKKLIRaC3O1WWmsd4FWk8z1AW6CdQFqmNLXcFfHhU3ylWr3rAqBerqNtvqmqjxeDmP9IZVKVBXt8GVEVQH1AWqA+oC1QF1gerYVhcV5H11tFT/n7p4mB+b9AqBurpNrLru1deKx5uv/HF0qKvb4MoIqkN+MHaEE0kDAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAtATposEZkg3QSeQgu0PyAbqIHGN3SD5AF5Fj7A7JB+ginjfUWh/LoX6uT+zMOqlqJB+gi/AB1mfmOEfQF94vZJYIJVcJkg/QRfgAk7ouzSj9RzTLVnZ2qa/Yv/QZJ1LKP2lOqATJB+gifIBZXRfeudbXrC4end8L9DUt6wubeEITI4UKkHyALsIH2KqLjGqlriPS2gsWlE18RaUzn7esAMkH6CJ8gK26Rvp8pa5L9qqBuTJS4kj/Et4FciDH2B2SD9BF5Bi7An2Ed5qIeTg40FBXt4G6QHXwxcleo6AuUDZGXW/evn1j1RVMzdBSdQF1dRujru9ms+9W6tJfQV2gHOyV8R/f01G26hrDu0BZWHX98HuH6tI0wy/QOay6iFBdC/1T7d5ltPW6eXC2QAFYVsJ6rjai6nrWPDhboAANUFdTr4yvoa6iNMK7mgnUVRioKxGoqzBQVyJQV2GgrkSgrsIkqSt4DGeqvD8BdXWbbXVtiKnyXx2hrm6zq67AVz+r42DyMD8OpnfzO6gL5CVGXRN1p6+DyViNg+kNvAvkJ1Zdv1Ghum7VLdQF8pJUqq+H/Op6Zn8dLQvZ6wZQV2GgLoPsdQOoqzBQl0H2ugHUVRiJriugrk7TXu96romwd55hwQ6hZK8bQF2Faa+6PO+2vL4tZK8bQF2FabO6Rr73UuszsjCaZSvzz/P2BCV73QDqKoCm/3pHXaerdnxjmTJDPY0s3tArujY/JajL9DP2itXlDY5z9wQle90A6kqJtBOPYLWl6GDIJlZdT3OlFnpC65700Tj4wJt8NbmlNWPefqmn9P9G3ermqGvgeyt15e4JSva6AdSVktfSUHxNgrrUnU86+sL37Ple/YQnweSPtILkxAs8vQkmjfKuo5W6BvAuB8QFyuprW11q8UjCWc431DWk9DGn0Tz9b4q6SkT2ugHUlZLkQG2pa0GCC7S/0L+e3N0bdZkn0E71fMxpD1rR/xsqhzlX12vRRRnE5wLqSklqdcXBzlURRdQlMyUAdRWjkLoqBOrqAp1Ul1zVigN1FaNL6uKqbqiub99+a9KK3YMLc2H3vALqSkmH1DWbzVgEVl3vZu9sKqkr/z04yYWmXZtlAepKSfvVZa6CxLMZi2A2kyvjLCx+FblLQrmwO9Uz8x0hUFc6CqjrUqaVkEFdMjXeRYTq+lGSC6qLrop627tAStKr61o9hU8yMnTA6LBVRg51bZS7vG/C9CL34MJcbJW7QEpSq2s5J0XxTdSf1cfAX07NDfulGtktSiePuiykrtJInwsQR3Z1mYfO5Ocg9fgnu0XpQF1dINuVcXExmPj80Fmorj9PzQblA3V1gUylek3+tQm3wKkEqKsLZFLXDtU9MAt1dYFi6qoOqKsL7FOXS9JLOrW6Yu7PHbpTAXUVY4+6ZOqK0tS1IaGHi+htOqirWnqhrof5Yr6cjs1tuuXU1nf95f1y+jC/m4/U58CXTbeBuorRC3WRRWk9MXfrxmood1Ps0mLywPfvZNNtoK5i9ERdy/ldqC6lJ0N7yy6YPKhbvqkCdVVED9RVAKirGFDXPqCuYkBd+4C6itFFdcktszKAugoB79oH1FUMqGsfUFcxoK59QF3F6Ly6FlrvNhxKC9RVjD3qco3k4xAH1MV3Uy+UPz49Nh1EZQPqKkayutpCCnXdLMyQ8aaDqExAXcXohbqWd/QWRDtJTAnUVYxeqEvdq7H2uYMoSUoL1FWMHqhLqacpSywHUFcxeqGu3EBdxYC69gF1FQPq2g/UVQSoaz9QVxE6qC65GVsSsleQh+6pCzQHqAtUB9QFqgPqAtUBdYHqgLpAdUBdoDqgLlAdUBeoDqgLVAfUBaoD6gLVAXWB6oC6QHVAXaA6oC5QHb1W1zPXSD46S6/VJc1PnQF1NR6oq7lAXQ7JGHu5nDpEMpIaqMswOJKZWsmqLvmYM6CuLHjeUGt9THGDutIAdWWBI6bPvMuv/JH/Ug/0iaf1lYljPUBdjacEdfkeq+tkoAfsY/WRU13avF9emEmdQF1Z4Iixui6MurwX2nvQdR6zzOp6ThdyfbKlrhe1nRJQVxY4Ymt1aX000M1Wl0cZNVk+1VeXF+f67Fz7pDj/XFvFVQzUlQUJmoG8q3Zyq4uu5f/t8kKfsNte0eWcSox1AHVlwXvtltzq0q/oyvjftUeepS9IXWS89vhXC9SVBcdDf+dX14jqtpcXQzItba6ONLHHv1qgriy0UF1Ogbqy0DZ1yQXVGVBXFkhddEa+f0+7CPeSOMxs+YTq0tpMDlNuv3eZyXw2QF2e981s9t7uJZi6UNdsNkspL6irfgp71/ffi3cF07v5Xa3qImWRtmbbRfKEYwJ11U9hdf3w25W6bur2Lj2L8a6kY0Lqouy+ef9Glpl8/fDnAurKhlXXjz+u1HWrbhtQ7tqvrne/eifLN/Rqq7qkwZg7JB+HKKaukAJ7yUvi0dqvrtez8AJ5o3x1LfM1UKq66A9xi+TjEH1Tlzf7nSzfUDWkrd5ljrBLJB+H6J263oZ5vVH38K68SD4OUUhdTsmhLpdUra7d9sH6TGYqQPJxiELqkplCe8lLz9XFbdXWTTteHG+qa8Q/nUJd+em5us7NXT5NCtK2kdqI3s9JcCP9y+OXRljm53pef8UN2M61z41C+FMlIPk4RJ/UJZFxRLnq8i5JKadXActFnwyOPVbXyfD4hfaGxwMrPZLY8pibo5PoTFu28hqyST4OkUsX2txm2lZXoLcLyafa1soiN1lL+72o595F6Au6/pFfnelXoi5vcHx+TW8kJV5/pv3lNTdHf8mbaTM1nyyO5OMQidvJD/sxWG0pyqhsKnv5pJQffPDH6laPg8n49PFprp700VI/nmoSlPYVpZG69FdQVyr2qYvVckJXPm62rV/RZU/UxeWxYzY2Lndp/fU1N0c3S3SV5Gk5SD4OkawuuSu7S4K6nsiVSFXha0y2dUeCojW0xMs8cPuY3+Bd6dinrj1wE8mqkXwcYo+6ZCaG2Cvj4oK9a0NdavE4VqSwRqrrQZeRjdSUqy65jLiiUnVZtq+MT/ojC2eshubKqMYLkuDdPS2p8MrI6lronxqhLs6MvY6rYQ13VUv2LpmR0NdN2i9N3C67utYs7mWmQkpQV+i0wWRRvY1BXVGKqKsOSlCXcVqjLkmqEqgrSl/URddxKoLNJbE6ylEXV6cICj0VrV01Ok9/vBO367y6aqYUdenZbMZToy5njc7TH2+oqybyqMvW/iPoGetrNrPe5arRefrjnbgd1FUuOdS1i/EuPbPe5azRefrjnbhd+eoKHmWmFHqprs1yl6tG5ymPN5G4XWZ10clj//QVG6eT+cGxRPqpLsHtZSP9lyZul0ddwWSkPge+8hfz5fRhzrfog8nDXN0/zUldPKvVR7NUHKjLkvZAl0raL03cLpe6pg/6mqZfyMH5px+jLprSklEX/zo0NkvFKVVdGxftsl3WAnVFyaOua3VL03t1v6QqDMtpcTGgqeJb9yt1maXiFFbXH9S/yFzkCh5M7uatUJdTHKgrJHKsqqSwuoZ0faaL9M/qo71+f+Qn0IzZ8nX9bv5vdJWXTcsA3hWl8+pSJCu6SN/xtdzYKj+BFuiP5K6UfMONKMr8cRvqipJbXTVRWF0X9iL9GzEss8SFRjXm6/qt+je6ypcI1BUljbqcUlRdcfxRphVQpbqomk4nR43Uoi6ZSf9tJVKBuuRWZTVUqq6/PJrrOTct1481NFdLe7wTt+uhuiqlUnXZmm54y6f65mppj3fidh1Ul1xSHVGputSYSosrddk1FZL2eCdutycY2lxDtp/aiNwljfx9keLAkz6yKyJp+bs5gndZTOgprNcL/Wu5oVh9c7VE1WyRuJ0EI+aED0snu3/icr4gheljfsKMigAkQlIUt1yfBx803z06ZWFG02748TS7j4xAXZa0B7pU0n5p4nahumJikuBd/DvjWH0xU2vSJoGd+oZTFAmKTrKNNHqDd2Wny+oSdtV1Z5VC2jESkpJAqCSlhsFkK82duhZary4gdXRDCHVFya4uPlqB9gP9iZ8wIwlxSeDu3l4FSUlDqizrrbQbfjzN7iMjxb2Lcnj6N7qCHxe4PqcH6oqSWV01k0FdXFDUseoyl+kiDpoeqCtKe9W1hSTvUdcU6spI2i9N3K616pLeLlZIcqK6tE9XxrzX5/RUrS4u1/JrhbRZK7e9uZD2eCdu11p17ZJwZbRUraqQStX19OdddRl2U0oh7fFO3K5D6rIkqKsuKlXXl6c5NziX10h9XqpRMJGma3fzW/UwPzZbl0Ta4524HdRVLpWq60JdkEvxrUZ+ccO0x3uSlW26xk+jcSmgRNIe78Tt8qsrvNIbV67kss9AXRaeW87VkBucm9eEm5+r8TSYSFvbW/Ku9quLLv4b0N9ZYaEG6rKkPdClkvZLE7fLri578ecHzY7Up5/VsVFXuY+ZRYC6LGkPdKmk/dLE7bKry178WVC3S2Wu+WaBTbmsx8wi1KYu+jOIwi4MdUXJrC5z8beCCv5um6uv1VXSY2YRCqsr+KT+VeZ2K/Krdby2lJ8hS1aXUxyoq2YKq8tqhp8EInX56ijwl/fLqX2YnNdxfd5X3LlMKaOhdUldkSO/nx6oS9t/CepSD49ktvywGVWvqJRorui8zl7buTpfymhopaqrLXRHXXJW7cCb8d36bXUtH9W/DtmT+Hruc1We//HD5BOzztTnqXZ/S95VwmhoUFeUNOpyyo66ZLpDgnfVDNQVJY26ZGbPXqojvboEqKt+oK6agLqi7FMXt6rfHYWqXnKoSy6pbth3nnaWHGOCWG3tPLUx1Nq3S0zl3RBnV5ccZmf0UF3SxC4LCeoiMQUf/KWmCn6ZY5klkVldoEHIwYv18/grI1foaTI2t+dLG20qCairzexTlyVWXWZEM6gL7CenusLxzUobyywJqKvNZFdXvUBdbQbqAtUBdYHqgLpAdUBdoDqgLlAdUBeojszqepqoqWnBWelN1BVQV5vJrK6F6TRdni63jzpUCdTVZjKrS6k78i55upz+aZNWGVBXm8msriVdEsf2STMe2kwtqnrG3wJ1tZnM6qoZqKvNQF2gOqAuUB1p1OUUqKvFpFGXzDg5slBXm+mcuvDURoOAusoG6lqTWV1bT5yZDrsWj5Xd9YK62kxmdfHvi+Pgg15qtdDcxH45Hz/oB81DnY5P5+b9Ud2a5RKAutpMTnWZX4HCkc5kcUEJ9p0SzJz5UDFyqeuF1lf2UO/hVGuZY/SJzBQG6lpTTF28cBcu8q/b9t2qy3ykKHnUNdBn3lpdCbrRvncuswzUVQVF1GVGOtNzu8hDnZLczPuYSmclDX2aR13GuC4vPH2mtaZyIk+OntPb12RXAyo3vtT6n4xxUZp3qf0RTU94vgygrjXZ1VUvRdV1Ra50fu096efaGx5ZwemX2jsP1fWKN3xFW6W5mqYB6lrTRXUNSTlXl+RQZ95zktOrF+RY16G6TklDpK7n+sgbDHwSFqvr4iVdGWlbEUghoK41XVQXX/1OXuoLNqoLb6TPzumiF6qL/Ip0RxtpfezpI6Ou5/qevevCqKMoUNeaFOqSqSPyqMspUNeaFOpyTFZ1oXe45nBYXQ3jsLpkxhFQVwSoq2SgrghdVJdco9wAdUXojrr0bMYTq65v335rEsOxNuoD6orQPnVJp8E7zAiteTQEUte72TvZ/kbdVj7UehSoK0Lr1CV9Bu/C6prpmVwZZ2Hx64Z/uZL5OoC6IrROXYlsXBm92Y8mEepySnfUJYi6vgnLZzfcx6vM1wHUFaGL6nIK1BUB6ioZqCsC1FUyUFcEqKtkoK4IUFfJQF0RoK6SgboiQF0lA3VF6Ly6Hi7KejwpHVBXhM6ra7ycBhPu5tVf3i+nI/VZ0qsC6orQfXWpYTBZdfP6oEt5QnwPUFeEHqhL6YnP3bzyv1tJrQ6oK0Ln1VU3UFcEqKtkoK4IUFfJQF0ROqguboDjDKgrSgfVJTOOgLoiQF0lA3VFgLpKBuqK0H11jWRaE84iKQ+vOEQyEqH76vp0oZT+arLg7oNrwJ26pF7hjD6q62n+RXGPm2P1RVKqBeqK0Hl1PWg9teqqB6grQufV9Ump+4X+iTt5lZRqaZC6BkcyUw99VJdlKNPqcamuIfeneGp7r35xDHWVT7y66sOlurhvTtvHtf+cXiPfs316nusTr6xOh5OBuqrHpbpe2j6u6Ujrk8GxN/KlP+KT4TEtVg3UVT0u1eVxR+n65Jw7ujbqOr/2XnBf6rTwUFKnw8lAXdXjUl3a9GOt/4m74T83V0aaOzLqGpTVpXUyUFf1uFSXW6Cu6nGnLuklzxm9VFed3SsRDtUlM47oq7qO1KeH+d28+qfNmJ6rS/roE/qgrtsnelvU8LQZ02N1URWCxDXTcqVkeqCu4M/qQd3SvzpwqS4qWr95/0aWmXo7XSRpGXVJgxyDrDKTDhB3Cj/WGGbH6nr3q3Vn13WrS2m9dWUUOq0uuiD2Rl2v151dK5//8trY84d3Wl214lhd3ux3snwTTOv2Lob8a4cuqYtj7Azn6nq77uz63oF3cbnLLEbpkLrMQXaIQ3U55XU4HkXM8OKdUVdvaUCRQM/ivQu0noYUOOPKXaD1oIsDUB0N8S7QSaAuUB1QF6iObXU9zNHZNSiLbXWNL0ldS/0YfNBLrarv6ADq6jI76lI+e9fYdkdcfUcHUFeX2VVX8JeJv1ZX1UBdXWZXXep2MtSiruo7OoC6usy2uuoG6uoyUBeoDqgLVAfUBaoD6gLVAXWB6oC6QHXsqKvORzYIqKvLxKjrbn6rjp4uBoG/nEpidUBdXSZGXTcqmHz5xc0N36yXxOqAurpMjLpuybuWn5aPUBcoCEr1oDqgLlAdUBeoDjxxBqqjt10cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABc8QxIJAAALeKZ13dgXQC0EFgXrAuAFgLrgnUB0EL2W9dAH8lcd4F1AdBC2LqeD7Xl+MSezSs2rUu229mKeXEam9wCYF0AtJCw1DXS/pnnvbzUX136ZyN2KF7mVDKso3NjWPR+IZvTrGxgZqyp+WecrK9km5YA6wKghexYF0+YczYrsa6PU3qjRVptrOnFqX7kBWtSZsuB/mjepiapTcC6AGghO9ZF5SoqO/nzc339alXq4qqjVAi56GUKVwTPyJZ2vfG2sGTWEmBdALSQBOvS+utd6xLHMqUxRiqIZkue83/Ji7AuAEDlhNbVX2BdALSQZ97rfgPrAqCNkHV5MhslLq170F8J6wKglcC6YF0AtBBYF6wLgBZircvesH7z/v37N9a0tq0rGE9krkvAugBoKxHrev9u9qvZu29Mcmhdwc3UTmFdAIAGES11vf5+9r1UH6PWNfDn6u4a1gUAaA5R6/J+mP32dzvWZQpeKHUBAJrEhnX9+PZHb8e61O29UrddLnVpTfP0xlMzDwBoOta6dohL6x7WukKzkqnGAwZpQGEVuAXWhVJXDlDPBq6BdeEczAHCBlzD1tVfcA7mBGEDrkGpC+dgDhA24BpYF87BHCBswDWwLpyDOUDYgGv2W9fCjgHkz+3iJu1/SAjWlReEDbjmYKmLjSkYfzj150sysUde5kWeY+saaf0VrKt3IGzANSmtS8zJ+Bb/N3M3U7PCvLUSWFdeEDbgmvTWtaRqIxsWrAsgbMA56a2L73tR3ZA9a2VdJvEnWFcGnjUayeRBYF3ANQetq8s4sS5pDdtIYF2gNcC6YF1rYF2gNcC6YF1rYF2gNcC6GmVdAx5p3B2wLtAaYF0OrOu5bemr9fGJtYwVsC4A0gHrcmBdzEj7Z5738lJ/demfjdjHeJlTydiOzq2t0UTrK/lEDcC6QGvIa13B5aPMbWNaUiSyf23NNMK6eMKcs1mJdX2c0tvxyYBm7MqagHWBBiN9gZruQLU+YF1PfyCn+Rf7rOKKBPsJLj/RB/41fm0jH3hshHVdmMKVPz/X169WpS6uOpKT0WrNG9QFrAu4IUWvgWFP7GE/xgesazG0j16P7tXT5/ni57lafjRt6OkVXPpzWgoHO4uYU7idSVm/N25UtAZZl9Zf71rXgNNhXaD7pBJUplIXc0cm9ECnEJkOn0tkUmJdMmFrCqcEJ9vtqBymqVpp3mltuKHZqhG4tK5GAusCbsghqAPWtbywbsMDmtHSb2z5asO6VoOdLdmnTIWRH3e0xavFkG+J0Tv7VuNGRXNjXa8bC6wLOKJ860rL0x9tkatdOLKuMgJeOtliAesCpeLGum6pdmgKZa0j2+laDrAuAHZwY13tJdvpWg6wLgB2yGld/cWZddmvf/P+/fs31rS2rYtvItYKrAs4JKd1yWyUuLTuke10zYueEWFjlKh1vX83+9Xs3TcmOQx49HfaWtmKxWamd4B1gVKBdWVj63QtA/mtbo01AfYBS7TU9fr72fcS/jDgbF1O2r9JLCSXYZ7lj9gF1gXKBNaVDTldy4T2t8nauuz/qHV5P8x++zsb6jDgztq/SSwkl2Ge5Y+IQz4HQAlUYV1Pp6Z1aTxygtV+npWEnK5lErM/4wOmATA/w7BhXT++/ZFvuBFhwJ21f1vFwuTyUIURgFIp37rElJb+nOf4FQ5pxuOZsa3dm1l9P/pkR95oE6vTtTwO7q+pxdwKYgFAWsq3LjGjxZdV23mCJrIUndxMF79oWbvUCk5XWBcA2SnfutiUiHWpi70sNKuNiVre3yX1g9NUKjhdYV0AZKd86yJH4h+cuOxFM78eT9ZDmhlbG3CF0UxM7xIto4LTNZV1NRJYF3BHFdaVmhY+xujKumQ2So6Al0sFsQAgLU6tq4VUcLrCugDIDqwrGxWcrrAuALKTz7pkrp80zLr4VqLcW9yFu6XlCf8osk1sYhZgXcAhsK7MNMy6CPsLyIdTfx42oZvYVnQ095cH7nU28ssup9Nm0tDu49SY33W4A9ljKmBdwCGwrsw01bqkDGVtSpJ4cmeaqUQSIrPhVFrhZQPWBRwC68pMg61r3YROkkwqFb02EiKz5gFIntqdZAPWBRwC68pMg61r3YROkkxqOA4AN7KTdLvur/YWGY+AYhsQZwPWBRwC68pM86zLEbAu4BBYV2ZgXQKsCzgE1pUZWJcA6wIOgXVlBtYlwLqAQ2BdmYF1CbAu4BBYV2ZgXQKsCzgE1pUZWJcA6wIOyWdd/aZx1pW9SVYpwLqAQ/JYF5BIlEM51rXknhs/mcet7+g1uldPnzM9kZgdWBdwCLTnnHKsS90+Pv3JzvEDiQ96z6hMJQHrAg6B9pxTknUFf/7zVAUPPKqZvKoG1gUcAu05p7h1WW5t7zayVAOwLuAQaM855ViXHUAW1gX6ArTnnHKsywGwLuAQaM85qayriVDWIB/gCmjPOWmsS+YaB+QDXAHtOSeNdTUWyAc4AtpzzmHrajSSSQDqBdblHBwCALKD88Y5OAQAZAfnjXNwCADIDs4b5+AQAJAdnDfOwSEAIDs4b5yDQwBAdnDeOAeHAIDs4LxxDg4BANnBeeMcHAIAsoPzxjk4BABkB+eNc3AIAMgOzhvn4BAAkB2cN87BIQAgOzhvnINDAEB2cN44B4cAgOzgvHEODgEA2cF54xw3h+CZdDDfW6D7lgPrcg6sywnQfcuBdTkH1uUE6L7lwLqcA+tyQrVB7314qxc1rMs57qzr+VBbjk+M2mhZ5noArKtaYF3dx22pa6T9ucz2C1hXtcC6uo9z6zrzvJeXVPbyz3iBZr/mkph/ds4TfSUbdg1YV7XAurpPQ6zrQhbs7ItTfWWsq6vOVYN1revj/zlaE5dYdx1YV/dpnnXRaTbS168ogc4+Xt1FqrcuhiK6XR+Psa5BB+8xwrq6T/Os679QceGITyiiswWE2qyLrd9MTDz1FceaXqsE/7+a0pn/T2apM6VcWFf3cWtdO8QUCjpJ7dZ1bguyHOCvzay9l8hXB1Pq6lj9HNbVfVxZ12vRWB+pPOgx1vXilOdf/De+NlB564rvJz7arQbial2qn8O6uo8765LZKHFp3cOJdUkxy1QY2baooGVqjLxmRJNf8kJ3Crywru4D66qd+qyrv8C6uo9L6xKZGUwyrKsc+l0frz6+BKzLOc6t6823b9++/faNSQ6tK7iZ2ul4YqbdYvPU0jNCy0JJ9LpQW8OlgYB1Oce5dX33bjb753ffmeQN6xpp/VWHrYvvLRFsXOxdr/eT7SDBumBd3ce5dXneP2bfy5kWsS5T4OpyqYtMy/631vVsH1kP0kZ4DSY5DG/HgXX1gwZY1w+z3/+4eW71wbqoqkj/0lUYC1hX/+rjsK6e0ADr8r6hl0mOnluLodY/ddq60lPAuvpXH2+sdeF333KPikvr2iEurXvUal39q4/DuhpLuUcF1lU7NVtX3+rjsK7GUu5RgXXVTs3W1bf6OKyrsZR7VGBdtVOXde3Qj/A23brM81fJ3Qzt6+f8xSl/9ip8wKt1lHtUYF21A+uqlkZb17nWF8p7/os4dzrQcRp5Hne/dg7rssC6agfWVS2Ntq6X3Jm56VxI+ks746ffiSPbra3t5zzs4na1lkyNTC/slMhYl3xMei+yvQrTFuFuw+UmUe5RaYN1BZePMhedjSV5fXPuScO6qqXR1kWwe12/stbCvXXYuetXUuoS6zqypTDbz5qd27Su8GNmeiUdg0gq7VaWG0W5R6Uu69LavHhCb4fOradTciDzlsjTH8iK/sX+VGaJNyfTiImnsC5YV3nkta5zsiT2l6tVf2kDW4Qy1sU2tW1dZG5kdscnXBLjDw9shXH9sVVPazz5v1bdsDWwA7Zyj0qOQ5CjV4Jn0lw8bDV+4NwSm+Ef8S/9uVkc0PTuekKznLT8OF0MKcVuuvh5riiFZ8NNb4+oAGa2Y+uSD/M+GwCsq1oabV2mwmgsiJyJMP6jj2zhiuZWFUbaxJTC2LHubXnMfoLmTKkr/JhJ5L5uzWS129Vygyj3qOSyrhxZyFTqYgPiybr9kSk78dT8Dze4s36l+DAZW9vaVBbDFP5IA2iUdR2qgbeQRltXZv5v8izSdyd6gSz3qOQ4BCUI49C5ZeqKSyonGcPht9t7pW5tqcta0vLTyqCWvwlLZHZTLnXdm1negHxLPiw7d41z6+LI3JkyaydprnWhF7UyybG/ErKQoVgQ4emP9rZVy2mEdbGpRyrji39To3v19LkLftZk65LZKAdE3xX6a123VCekslMXcG9dl1p/nBrXMhbG9WkVPJhat92i1cC6mkh/ratDuLcu9iyZ8BvVp6nUxbXqTtBs65Lqk8Ek90P0FRyVHPsrIQt8FPtL5ghm3R7X93JPkhhSfcVmX2wR60IvaiWQY38lZKHX5xasq1rqsi7pezuZVRe4loh1oRe1EsixvxKyAOuS+XRk3R7WVe5JEsNr6Xt7Hyvrsv8j1oVe1Eogx/5KyAKsS+bTkXV7Dm+PKf0kycuqwmj68t6wLvSiVpgc+yshCwesi38CO/RrV/wR5m6oiEY3WqrHumQ2SlxaB2mOdW2yYV3oRa0wOfZXQhYOWZc5eksyIDqWpmHqh1P+OV8tyZYe7SJxz9vRi5f9ud1UPiyp+pE+8WgcrTm/+8O6qqXZ1rUDjkpOcuyvhCyksi5jPxO1+GImkhimmkV5rZZpU9lOUuXFE7OuEcC6qgXW1UR6ZV0D+zBPuEwFai6HiROZNHmtlg3hEk/lZZIag3vreqJC63YrrvgYcdXdFHubFMADwLqaSF+si+91mftV3Mbbnwfjv5plvhXwVehEAzr7qDr463DZbirnIL3xdPWSdY3AuXWFz/tINdrUwo2bmahxNZtW2p/pJYA8sZV1s+JTs2rgW8C6mkhPrGsbPnO6g3PrUuqOjZyjKtVocafNSTi942tHdDN7QJpTA98C1tVEempd3aIB1sUlrkfxo0gtfHOydiqei1bWeYaTmwmsq4nAujqAc+viejfX/Ww1WmrhXAEXa+IXp/4Uta5wM54+NqsGvgWsq4nAujqAc+tKyWLYzgeyW2pdwaX+xBN7segcsK4O0BbraitttS6qlNuuiMIOy7mHcv4tilLb35karKsDwLqqpb3WRQXdTzzZ6LCcX1w/b+5Puqlos3WZbul5snqca4fD51ZsV+pp+1dvyEhnsK5qabF1cUuV68lWh+X8an9nag20LungYz8yFJB5CpWnaY7i0rQiimCP7Raxic0e6QzWVS0tta6O00Tr8qSLj33ksS7zbuv41mF4mV7hYGb7RjBr9EhnsK5qgXU1kWZal8wdIEOFkT2G3m+mYR0/uOQf5K37rEwoekPAmFtkJdHYkc6aZF0xdehaY1EFsK4m0mbripLGugZcElrV8aUJJduNnewdwazRI501wLr4z9/GeDhPY9a1iiZbV48p/ajk2N/mR3JlqNcXoIZYV/BALs72zWOa8cM+ZF3NGiY8J022LpmN0g/RV3BUcuxv8yO5MgTrkvl0HN6ea+H0MpXyg4OLi3Vx6Yqti6fcs1DjhgnPCayricC6OkAe69rPM3sbUX4ESVvqCq3rkmvMVId2UXmuAlhXE+mSdfWXCk6tjKWuKK0vZW3TXusaHdFbeDzSHJcWHbsuWZfMRok/t7pG9acWrKva+Obj4FEZfLozPy/Z3syj07D78hGtX/p/oyO20cma6UTN3LmUztYaCKyrAzTMujpHW63r6fOc+0AzVkRv29P1/UiTslonE9OWyC6avTUNWFcHqMe6ekzl8c3HAdGbroGpmBX1ofVUDGl5f2caOO52sgbrSsHmR3Jl6LB1mWp/MsH4f3KnU83tNGoP9ViXzEaJS+sgLbUurgwqdUcVQNub+XrKXhR2kMY/pFDKZidrlLzaFNa1h82P5MrQwXNrXe2nmr15m9h6/tx2kW4OUPhmq/i0gqr59p5Ao4F1VUtLravj9MW6tqr91qCoQGwbfBu32rAuu6nMNrbTdAHWVS2wribSE+varPaHb6aevz2eWbggL5PUcBpgXVzf4CF5I6SKXMznGA58cx4jgnU1kZ5Y17raHzEoW8+XSv7GGp6uXg3uNF1wb102vquYUVX74/+wQzNGf2SP1sDtL/TyORnXzKaFo56xddlZu407Gmxd/abko5Jjf5sfyZWhXl+Aqjm1TGtUntD0QHif/rguIdGLJ2sfi/5SRS+e8K/yvCb8HCOr5CPGutbLbmmsdQGJRDnAumrn4KklF6n0ZOwObTG0zRbZZqzVsPeEC7vWJZuuPhdbaYd1gXqBddXOYetK03tjlIzWReUnqh6S/1DFjwcPv+TxrPl39u0f2c3L1MDFkeznopV2U4PnUc+owiizvKFLYF39IMdR3vxILpnAumQ+llwhzVBh7Diwrn6Q4yhvfiSXTGBdMh9L4TMP1lUwgKAF5DjKmx/JJRNYl8zHUvjMg3UVDCBoATmO8uZHUu6A6zH0MtWajL2yMLt9qMvdlxZSi3X1m6IBBC2gnud0c/WFFw/fDzZTWFcicve+z0gkAIiweWalPM8ylrrYmEzn6euxyFyOP1Yq1VsXACCGXNa1STrrMuWq1VhkksQNiLjgZde2EVgXAE6o1brWY5FJEvtWu7tQh3UB4IQ6rKvLwLoAcAKsqxiwLgCcAOsqBqwLACeUZF39BdYFgAtKsi6ZjYJSlwHWBUAVwLqKAesCwAmwrmLAugBwQg3WZYb1jbY6jcy2HlgXAE6o3rqePnPv8ta/TD/oqxHK+cVdqa97Gm4fsC4AnFC9dSl1F3bWydA0tC2ZbTWwLgCcUId1mY7Q2aQ2Ryg3r7ZXH2FdADiheuviTs55IK2Bvpd+0E3P6RtdqbcXWBcATqjeuroNrAsAJ8C6igHrAsAJsK5iwLoAcAKsqxiwLgCcAOsqRvXWJf2z9xmJBAARYF3FqMG6pIuK/gLrAjHUZl27I5hF4bVL7c/5JUntANZVPbAuEEMd1pXc6NSsWXKrLzvfvuapsK7qgXWBGGqzLnozI5hxa9SPUzW654cbrVXxqnUbex5ng1fRxirczA59xuOeLf5N0uyundMx6xro4xOZbQ6wLhBDrdYl5sSzD+GwZrz+xgzNGK6NrIrM8xZmwFlJM3t2T23WNaK/mriyS1FenGaym+QdEbAu0BYcWZcZwkzWDMiHImujqyLz/KIlKnXZtIZQk3W9vNT+mTmPae6C/YcWz9mC/p2fs1ot0arnQ31E8/7ZwCR7ZgXN0Ae/uvT/39WOrIetVpzxsv9Lti6zp3hrcwKsC8RQh3V1mZqsi2xIvGRtXQP9ccopND2hope+59nrV2RdH6e0lZnzz2jFI3/oil7kT+sdGc7JquwKswP6xPFJuN/GAOsCMcC6ilGTdZGxHJnTOFrqolkuZ5lK3jlZldnsiktdpuhltzJFKN7OfnC9Iy6ZzfljdoXdgdmX7LcxwLpADLCuYtR1r8vYCXFl63lc06MCFHFh6nf+mSSLa62tS7b3z6xDrXdkPO3rlXXRJwxc6mJgXaDZlGRdveVgzEqyrj4D6wIxlGNdvaZy65Lv6SuwLhBHGdbVeyQQsZRhXX2ujxcPIOgmJVgX2AesqwiwLpAErKtiYF1FgHWBJGBdFZMnpPwLn8yG1mVvWL95//79G2ta29Zlm/B2DVgXSALWVTHZQ6pnhtC8Itb1/t3sV7N335jk0Lrs01GwLtA3YF0Vk73hCFmXFvtioqWu19/PvpfqY9S6Bv5c3TXmsc4ygXWBJGBdjWNV6qJqI71Hrcv7Yfbb3+1Ylyl4odQF+gWsq4Ek3uvyfnz7IzeDJSLWZR5Iv0WpC/QKWFfTsda1Q1xa94B1gSRgXU0H1gVNghhgXU0H1gVNghhgXU2Hrau/QJMgAVhX00GpC5oEMcC6mg6sC5oEMcC6mg6sC5oEMcC6ms4B67KDvnW0RSqsCyQC62o6h6xr/JeHR2tdS631I819ONWPNE+pi2Fzhn3LBawLJAHrajoHrWui7nwZjJeXeE5ePFl8abN3wbpAErCuppPCuujtL+PJkmqO4lfyMutaDawLJAHrajpprMs8wki1Q/3VhnWZkcLNrbC2AusCScC6ms4B6+o2sC6QBKyr6cC6oEkQA6yr6cC6oEkQA6yr6cC6oEkQA6yr6cC6oEkQA6yr6cC6oEkQA6yr6cC6oEkQA6yr6Ry0rqe//9mOZ9ZB+mhdz6Srsv6S7oDDuprOIetafJk8fZ6r1Yhmo3tlljsBrKuPwLq6wSHrGnwyr3BEM25A3/JnriPAuvoIrKsbHLAufnJRLYaPqxHNeNoZYF19BNbVDbLcpn/6Y8fuevXYugY8GufxiV3Y4vkwaU0ngHV1g7TWdUtK71KBy9Bb6zrX+kJ5z39xQha24VJbi50E1tUNspS6OkdvrevlJV2Jrkz5ivDPRjzRR+tF/8yzafpINuJ0cjyCPtdqYF3dgK2rv/TVugh2r+tXUsyynrRaZOs650Xvxam+Ius6suUxs1nbnQvW1RFQ6uqjdZ2TF7FfXZEjGcMypSwzx4bF1kWmZQzr+tXauuhDtEDbthpYVzeAdfXRukyFkQ2JbYq8iN6ObDFLFtmewjLW2rrMvf0L/lSbgXV1A1hXH62r18C6usF+6+JenYlW9+K8h35aF25upgHW1XQOlrq4E/rbT9w49W88jtnHaQcGMQvpq3XJbJS4tO6xfcD5uiyz28C6mk4q6wpupotfTHmOF3na7kHMQraV3AdgXasDrmeGePOCdTWdVNallvd3PHosW9eNtbBOsKnkfmAPuNSfDCY5TgTdwx5wsSxG07yWOGwD62o26azLPLoYjP9qb3u1fhCzEKtkWegJEet68+3bt2+/fWOSwwNunrPnaWeuT1HCA071RCps7S11bQLrah7p6g/m6cXuqTlUcp+IWNd372azf373nUkOD7ixrpEZclNSusT2Ad9zr2sTWFfzSGddHWVbyX0gYl2e94/Z93L4wwMe3hDodqkrM7Cu5gHr6rN1/TD7/Y/2UIcHvFfWZWqMqYpdsK7mQUruN722Lu8bepnkiHWZ1nw/ddm6uJ5ImDtd5F2ihL3AuhrHMyCR6AkoZpN1kV+Z/9a6RAcHkF0AAJwA62IT0vQvS4URAOAYWBfKTwC0EFgXrAuAFgLrgnUB0EJgXbAuAFoIrAvWBUALOWBdwaX+xJNONuuCdQHQWg5Z13iy/DjlyeLnuaLZ4NKfL/U9z6rRvXr63Obn7mFdALSVw9alFsNPPOGe6K9N72zy4h5D2t3JJKwLgLaSwrqUWpJDLX8zV3cb1mW6Pmo1sC4A2gpu08O6AGghsC5YFwAtBNYF6wKghbB19RdYFwAtBaUuWBcALQTWBesCoIXAumBdALSQ/dbFfTsTnRiqLgZYFwBt5WCpyzZKHRn/GtmBg5/+FIw/nOpHu0GLgXUB0FZSWZexr+Bm+vR5Pvj//6T+Y9WmvuXAugBoK5msS93+9L/Vf3z40zqx3cC6AGgrKSuMt/aGFy88/cHaFqwLAOCMg9bVZWBdALQVWBesC4AWAuuCdQHQQsi6+g2sC4A2IsPQ9xmJBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgGag1P8BV2KEohd7diMAAAAASUVORK5CYII=)

## Project Skeleton Overview

You are given a **project skeleton** , which includes the following items:

- **Stations.App** – contains the **Startup** class, which is the **entry point of the application**. Also contains an **AutoMapper** profile, which you can configure if you choose to use **AutoMapper** in your app.
- **Stations.Data** – contains the **StationsDbContext** class and the **connection string**
- **Stations.Models** – contains the **entity classes**
- **Stations.DataProcessor** – contains the **Serializer** and **Deserializer** classes, which are used for **importing** and **exporting** data

## Problem 1. Model Definition (50 pts)

Every **trip** has an origin **station** and destination **station** , it also includes information about which **train** travelled between those two stations. Each train may have **seats** , which are grouped in **seating classes** ( **First class** , **Second class** and so on). For each trip, you may buy a **ticket**. the **ticket** keeps information about the trip and **may** include information about the **customer** who bought it through their **customer card** ( **if** they have one). The **customer**** card** contains basic person data.

**Note: Foreign key navigation properties are required!**

The application needs to store the following data:

### Station

- **Id** – integer, **Primary Key**
- **Name** – text with **max length**** 50**(**required, unique**)
- **Town** – text with **max length**** 50**(**required**)
- **TripsTo** – Collection of type **Trip**
- **TripsFrom** – Collection of type **Trip**

### Train

- **Id** – integer, **Primary Key**
- **TrainNumber**  **–**  **text with**  **max length**** 10 **** ( ****required**** , **** unique****)**
- **Type**  **–**  **TrainType**  **enumeration with possible values: &quot;**** HighSpeed ****&quot;, &quot;**** LongDistance ****&quot; or &quot;**** Freight****&quot; (****optional****)**
- **TrainSeats** – Collection of type **TrainSeat**
- **Trips** – Collection of type **Trip**

### SeatingClass

- **Id** – integer, **Primary Key**
- **Name** – text with **max length 30** ( **required, unique** )
- **Abbreviation** – text with an **exact** length of **2** ( **no more, no less** ), ( **required, unique** )

### TrainSeat

- **Id** – integer, **Primary Key**
- **TrainId**  **–**** integer ( ****required**** )**
- **Train**** – ****train whose seats will be described** **(required)**
- **SeatingClassId**** – ****integer** **(required)**
- **SeatingClass**** – ****class of the seats** **(required)**
- **Quantity**  **–**  **how many seats of given class total for the given train** **(required, non-negative)**

### Trip

- **Id** – integer, **Primary Key**
- **OriginStationId** – integer **(required)**
- **OriginStation** – station from which the trip begins ( **required** )
- **DestinationStation**** Id **– integer** (required)**
- **DestinationStation**** – ****   **station** where the trip ends ( ****required**** )**
- **DepartureTime** – date and time of departure from origin station ( **required** )
- **ArrivalTime** – date and time of arrival at destination station, must be after departure time ( **required** )
- **TrainId** – integer **(required)**
- **Train** – train used for that particular trip ( **required** )
- **Status** – **TripStatus**** enumeration **with possible values: &quot;** OnTime **&quot;, &quot;** Delayed **&quot; and &quot;** Early**&quot; (**default **: &quot;** OnTime**&quot;)
- **TimeDifference**  **–**  **time**** (span)****representing how late or early a given train was (****optional****)**

### Ticket

- **Id** – integer, **Primary Key**
- **Price** – decimal value of the ticket ( **required, non-negative** )
- **SeatingPlace**** – ****text with**  **max length**  **of**  **8**  **which combines**  **seating class abbreviation** **plus a positive integer (****required****)**
- **TripId** – integer **(required)**
- **Trip** – the trip for which the ticket is for ( **required** )
- **CustomerCardId**** – **** integer ( ****ptional**** )**
- **CustomerCard**** – ****reference to the ticket&#39;s**  **buyer**

### CustomerCard

- **Id** – integer, **Primary Key**
- **Name** – text with **max length**** 128**(**required**)
- **Age** – integer **between**** 0 and 120**
- **Type** – **CardType** enumeration with values: &quot; **Pupil**&quot;, &quot; **Student**&quot;, &quot; **Elder**&quot;, &quot; **Debilitated**&quot;, &quot; **Normal**&quot; (default: **Normal** )
- **BoughtTickets** – Collection of type **Ticket**

Any information which has additional requirements needs to be **validated**.

## Problem 2. Data Import (35pts)

For the functionality of the application, you need to create several methods that manipulate the database. The **project skeleton** already provides you with these methods, inside the **Stations.DataProcessor** project inside your solution. Use **Data Transfer Objects** as needed.

Use the provided **JSON** and **XML** files to populate the database with data. Import all the information from those files into the database.

You are **not allowed** to modify the provided JSON and XML files.

**If a record does not meet the requirements from the first section, print an error message:**

| **Error message** |
| --- |
| Invalid data format. |

### JSON Import (15 pts)

#### Import Stations

Using the file **stations.json** , import the data from that file into the database. Print information about each imported object in the format described below.

- If the town name is not given, insert it with the same value as the station name.
- If a station with the same name **already exists** , **ignore** the entity.
- If any other validation error occurs (such as **long**** station ****or**** town name**) proceed as described above.

##### Example

| **stations.json** |
| --- |
| [  {    &quot;Name&quot;: &quot;Sofia&quot;  },  {    &quot;Name&quot;: &quot;Sofia Sever&quot;,    &quot;Town&quot;: &quot;Sofia&quot;  },  …] |
| **Output** |
| Record Sofia successfully imported.Record Sofia Sever successfully imported.… |

#### Import Seating Classes

Using the file **classes.json** , import the data from that file into the database. Print information about each imported object in the format described below.

If a seating class with the same **name** or **abbreviation** already exists, **ignore** the entity.

If any validation error occurs (such as **long name** or **incorrect**** abbreviation ****length** ), proceed as described above.

##### Example

| **classes.json** |
| --- |
| [  {     Name:&quot;First class&quot;,
     Abbreviation: &quot;FC&quot;,  },  {     Name:&quot;Second class&quot;,
     Abbreviation: &quot;SC&quot;,  },  …] |
| **Output** |
| Record First class successfully imported.Record Second class successfully imported.… |

#### Import Trains

Using the file **trains.json** , import the data from that file into the database. Print information about each imported object in the format described below.

##### Constraints

- Train type will always be a valid type (if not null). If it&#39;s **null** , use the **default type** ( **HighSpeed** ).
- If there is no **seat class** with given **name** and **abbreviation** in any of the train&#39;s **seats** – **skip** thewhole entity.
- If there is seat class with same name but different abbreviation **or the quantity is negative** – **ignore** the whole entity.
- **Any** of the properties **may**** be**not given (null) in the json file (including the**quantity**of seats per train) – if the specific property is**required **and it has** null value **the whole entity is considered** invalid**.
- If any **validation error** occurs (such as **long train number** ), proceed as described above.
- There will be **only one** seat class with same name **per** train:

| [  {    &quot;Seats&quot;: [      {        Name:&quot;First class&quot;,
        …      },      {        Name:&quot; First class&quot;,
        …      }    ]  }] |
| --- |

**The input above will not be presented!**

##### Example

| **trains****.json** |
| --- |
| [  {    &quot;TrainNumber&quot;: &quot;KB20012&quot;,    &quot;Type&quot;: &quot;HighSpeed&quot;,    &quot;Seats&quot;: [      {        Name:&quot;First class&quot;,
        Abbreviation: &quot;FC&quot;,        Quantity:50      },      {        Name:&quot;Business class&quot;,
        Abbreviation: &quot;BC&quot;,        Quantity:44      }    ]  },   …] |
| **Output** |
| Record KB20012 successfully imported.… |

#### Import Trips

Using the file **trips.json** , import the data from that file into the database. Print information about each imported object in the format described below.

If there is any violation of the requirements mentioned in the first section or some of the stations/trains do not exist **ignore** the whole entity and **continue** with next one.

If status is not specified use the **default** one.

##### Constraints

- Status will always be a valid value or null
- Time Difference may be null or be represented in format &quot; **hh\:mm**&quot;
- Arrival/Departure date may be null or in format &quot; **dd/MM/yyyy HH:m**** m**&quot;
- Always check for the existence of trains and stations.
- Always check if **departure time** is before the **arrival** one.
- Any of the properties might be null – if the property is considered required consider the **whole entity** as invalid.

##### Example

| **trips.json** |
| --- |
| [  {    &quot;Train&quot;: &quot;KB20012&quot;,    &quot;OriginStation&quot;: &quot;Sofia&quot;,    &quot;DestinationStation&quot;: &quot;Sofia Sever&quot;,    &quot;DepartureTime&quot;: &quot;27/12/2016 12:00&quot;,    &quot;ArrivalTime&quot;: &quot;27/12/2016 12:30&quot;,    &quot;Status&quot;: &quot;OnTime&quot;,  },  …] |
| **Output** |
| Trip from Sofia to Sofia Sever imported.… |

### XML Import (5 pts)

#### Import Person Cards

Using the file **cards.xml** , import the data from the file into the database. Print information about each imported object in the format described below.

If any of the model requirements is violated continue with the next entity.

##### Constraints

- Card type will be valid value or null (if null set default value)
- There will be no any other missing(null) elements

##### Example

| **cards****.xml** |
| --- |
| \&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?\&gt;\&lt;Cards\&gt;  \&lt;Card\&gt;    \&lt;Name\&gt;John Levit\&lt;/Name\&gt;    \&lt;Age\&gt;25\&lt;/Age\&gt;    \&lt;CardType\&gt;Normal\&lt;/CardType\&gt;  \&lt;/Card\&gt;  \&lt;Card\&gt;    \&lt;Name\&gt;Ana Keanig\&lt;/Name\&gt;    \&lt;Age\&gt;19\&lt;/Age\&gt;    \&lt;CardType\&gt;Student\&lt;/CardType\&gt;  \&lt;/Card\&gt;  …\&lt;/Cards\&gt; |
| **Output** |
| Record John Levit successfully imported.Record Ana Keanig successfully imported. |

#### Import Tickets

Using the file **tickets.xml** , import the data from the file into the database.

Find the trip with the specified data (by origin/destination station and departure time). Assume there will be exactly one or zero trips available (there will be no trips with same departure time and origin/destination station).  If there is existing trip use the train referenced there for the next part.

The **seat** must be a combination between seating class **abbreviation** and **integer** number (e.g: &quot; **FC42**&quot; - where &quot; **FC**&quot; stands for &quot; **First Class**&quot; and &quot; **42**&quot; is **number** of the specific **seat** ) – this means that you should check if there is a **class** with same abbreviation and then check **if** the **train** has **any**** seats **from that class. Last, the seat number must be positive and** below ****or**** equal **to the** quantity** of seats specified for that train.

If the format of the seat doesn&#39;t match the above criteria, the entity is invalid.

##### Constraints

- Ticket&#39;s price will always be a valid number ( **not null** )
- Ticket&#39;s seat will not be null
- If there is no existing trip with matching properties or there is **no card** with matching name in the database, **ignore** the whole entity.
- Departure time will be a valid datetime in the format: &quot; **dd/MM/yyyy HH:mm**&quot;
- Cards will not have duplicate names
- If any validation error occurs, proceed as described above.

##### Example

| **tickets****.xml** |
| --- |
| \&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?\&gt;\&lt;Tickets\&gt;  \&lt;Ticket price=&quot;3.53&quot; seat=&quot;SC12&quot;\&gt;    \&lt;Trip\&gt;      \&lt;OriginStation\&gt;Sofia\&lt;/OriginStation\&gt;      \&lt;DestinationStation\&gt;Sofia Sever\&lt;/DestinationStation\&gt;      \&lt;DepartureTime\&gt;27/12/2016 12:00\&lt;/DepartureTime\&gt;    \&lt;/Trip\&gt;  \&lt;/Ticket\&gt;  \&lt;Ticket price=&quot;3.28&quot; seat=&quot;FC1&quot;\&gt;    \&lt;Trip\&gt;      \&lt;OriginStation\&gt;Sofia\&lt;/OriginStation\&gt;      \&lt;DestinationStation\&gt;Sofia Sever\&lt;/DestinationStation\&gt;      \&lt;DepartureTime\&gt;27/12/2016 12:00\&lt;/DepartureTime\&gt;    \&lt;/Trip\&gt;    \&lt;Card Name=&quot;Amber Hosh&quot; /\&gt;  \&lt;/Ticket\&gt;  \&lt;/Tickets\&gt;… |
| **Output** |
| Ticket from Sofia to Sofia Sever departing at 27/12/2016 12:00 imported.Ticket from Sofia to Sofia Sever departing at 27/12/2016 12:00 imported.… |

## Problem 3. Data Export (15pts)

For the functionality of the application, you need to create several methods that manipulate the database. Create these methods inside the **data layer** of your solution. **Database query methods will be assessed separately from export functionality.** Use **Data Transfer Objects** as needed.

Create a **new project** inside your solution that would handle data **export** **(where serialization would happen)**.

### JSON Export (5 pts)

#### Export All Delayed Trains

The given method in the project skeleton receives a **date** as string in format &quot; **dd/MM/yyyy**&quot;. Export all trains which were part of trip with status: &quot; **Delayed**&quot; and also the trip&#39;s departure time is **smaller or equal** to the given date. Display only unique trains alongside with how many times they have been late and their highest delay in format: &quot; **HH:mm:ss**&quot; (the **default** Timespan format). Order the trains by: count of how many times they have been late (descending), highest delay time (descending) and train number (ascending).

| **delayed-trains-by-01-01-2017.json** |
| --- |
| [  {    &quot;Tra1inNumber&quot;: &quot;PU17333&quot;,    &quot;DelayedTimes&quot;: 2,    &quot;MaxDelayedTime&quot;: &quot;23:02:00&quot;  },  {    &quot;TrainNumber&quot;: &quot;VT08003&quot;,    &quot;DelayedTimes&quot;: 2,    &quot;MaxDelayedTime&quot;: &quot;15:51:00&quot;  },  {    &quot;TrainNumber&quot;: &quot;BQ877549&quot;,    &quot;DelayedTimes&quot;: 1,    &quot;MaxDelayedTime&quot;: &quot;21:39:00&quot;  },  …] |

### XML Export (5 pts)

#### ExportCards by Type

Use the method provided in the project skeleton, which receives a **card type**. Your task is to export all tickets bought by people with the same card type. Order by **card name** in ascending order.

#### Example

| **tickets-bought-with-card-type-Debilitated.xml** |
| --- |
| \&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?\&gt;\&lt;Cards\&gt;  \&lt;Card name=&quot;George Powell&quot; type=&quot;Debilitated&quot;\&gt;    \&lt;Tickets\&gt;      \&lt;Ticket\&gt;        \&lt;OriginStation\&gt;Sofia\&lt;/OriginStation\&gt;        \&lt;DestinationStation\&gt;Varna\&lt;/DestinationStation\&gt;        \&lt;DepartureTime\&gt;24/05/2017 12:00\&lt;/DepartureTime\&gt;      \&lt;/Ticket\&gt;      \&lt;Ticket\&gt;        \&lt;OriginStation\&gt;Sofia\&lt;/OriginStation\&gt;        \&lt;DestinationStation\&gt;Sagay\&lt;/DestinationStation\&gt;        \&lt;DepartureTime\&gt;02/12/2016 12:20\&lt;/DepartureTime\&gt;      \&lt;/Ticket\&gt;    \&lt;/Tickets\&gt;  \&lt;/Card\&gt;  \&lt;Card name=&quot;Henry Moreno&quot; type=&quot;Debilitated&quot;\&gt;    \&lt;Tickets\&gt;      \&lt;Ticket\&gt;        \&lt;OriginStation\&gt;Ajjah\&lt;/OriginStation\&gt;        \&lt;DestinationStation\&gt;San Isidro\&lt;/DestinationStation\&gt;        \&lt;DepartureTime\&gt;02/04/2016 12:33\&lt;/DepartureTime\&gt;      \&lt;/Ticket\&gt;    \&lt;/Tickets\&gt;  \&lt;/Card\&gt;\&lt;/Cards\&gt; |

#### Other case

| **tickets-bought-with-card-type-Elder.xml** |
| --- |
| \&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?\&gt;\&lt;Cards\&gt;  \&lt;Card name=&quot;Jeremy Carroll&quot; type=&quot;Elder&quot;\&gt;    \&lt;Tickets\&gt;      \&lt;Ticket\&gt;        \&lt;OriginStation\&gt;Sofia\&lt;/OriginStation\&gt;        \&lt;DestinationStation\&gt;Varna\&lt;/DestinationStation\&gt;        \&lt;DepartureTime\&gt;24/05/2017 22:00\&lt;/DepartureTime\&gt;      \&lt;/Ticket\&gt;      \&lt;Ticket\&gt;        \&lt;OriginStation\&gt;Huaian\&lt;/OriginStation\&gt;        \&lt;DestinationStation\&gt;Chysky\&lt;/DestinationStation\&gt;        \&lt;DepartureTime\&gt;13/08/2011 12:33\&lt;/DepartureTime\&gt;      \&lt;/Ticket\&gt;      \&lt;Ticket\&gt;        \&lt;OriginStation\&gt;Sofia\&lt;/OriginStation\&gt;        \&lt;DestinationStation\&gt;Varna\&lt;/DestinationStation\&gt;        \&lt;DepartureTime\&gt;24/05/2017 12:00\&lt;/DepartureTime\&gt;      \&lt;/Ticket\&gt;      \&lt;Ticket\&gt;        \&lt;OriginStation\&gt;Sofia\&lt;/OriginStation\&gt;        \&lt;DestinationStation\&gt;Varna\&lt;/DestinationStation\&gt;        \&lt;DepartureTime\&gt;24/05/2017 12:00\&lt;/DepartureTime\&gt;      \&lt;/Ticket\&gt;    \&lt;/Tickets\&gt;  \&lt;/Card\&gt;  \&lt;Card name=&quot;Michelle Sanders&quot; type=&quot;Elder&quot;\&gt;    \&lt;Tickets\&gt;      \&lt;Ticket\&gt;        \&lt;OriginStation\&gt;Matriz de Camaragibe\&lt;/OriginStation\&gt;        \&lt;DestinationStation\&gt;Chysky\&lt;/DestinationStation\&gt;        \&lt;DepartureTime\&gt;23/11/2016 15:09\&lt;/DepartureTime\&gt;      \&lt;/Ticket\&gt;    \&lt;/Tickets\&gt;  \&lt;/Card\&gt;  \&lt;Card name=&quot;Wanda Ward&quot; type=&quot;Elder&quot;\&gt;    \&lt;Tickets\&gt;      \&lt;Ticket\&gt;        \&lt;OriginStation\&gt;Sofia\&lt;/OriginStation\&gt;        \&lt;DestinationStation\&gt;Sofia Sever\&lt;/DestinationStation\&gt;        \&lt;DepartureTime\&gt;27/12/2016 12:00\&lt;/DepartureTime\&gt;      \&lt;/Ticket\&gt;    \&lt;/Tickets\&gt;  \&lt;/Card\&gt;\&lt;/Cards\&gt; |